using AutoMapper;
using GameStore.Application.Dtos.Games;
using GameStore.Application.Dtos.Publisher;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly GameStoreDbContext _context;
        private readonly IMapper _mapper;

        public PublisherService(GameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto dto)
        {
            if (await _context.Publishers.AnyAsync(p => p.CompanyName == dto.CompanyName))
                throw new BadRequestException("Company name must be unique.");

            var publisher = _mapper.Map<Publisher>(dto);
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<PublisherDto> GetPublisherByCompanyNameAsync(string companyName)
        {
            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(p => p.CompanyName == companyName);

            if (publisher == null)
                throw new NotFoundException("Publisher not found.");

            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
        }

        public async Task<PublisherDto> GetPublisherByGameKeyAsync(string gameKey)
        {
            var game = await _context.Games
                .Include(g => g.Publisher)
                .FirstOrDefaultAsync(g => g.Key == gameKey);

            if (game?.Publisher == null)
                throw new NotFoundException("Game or associated publisher not found.");

            return _mapper.Map<PublisherDto>(game.Publisher);
        }
        public async Task<PublisherDto> UpdatePublisherAsync(UpdatePublisherDto dto)
        {
            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(p => p.Id == dto.Id)
                ?? throw new NotFoundException("Publisher not found.");

            if (publisher.CompanyName != dto.CompanyName &&
                await _context.Publishers.AnyAsync(p => p.CompanyName == dto.CompanyName))
            {
                throw new BadRequestException("Company name must be unique.");
            }

            publisher.CompanyName = dto.CompanyName;
            publisher.HomePage = dto.HomePage;
            publisher.Description = dto.Description;

            await _context.SaveChangesAsync();
            return _mapper.Map<PublisherDto>(publisher);
        }
        public async Task DeletePublisherAsync(Guid id)
        {
            var publisher = await _context.Publishers
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (publisher == null)
                throw new NotFoundException("Publisher not found.");

            if (publisher.Games.Any())
                throw new BadRequestException("Cannot delete publisher associated with games.");

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<GameResponseDto>> GetGamesByPublisherNameAsync(string companyName)
        {
            var publisher = await _context.Publishers
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.CompanyName == companyName);

            if (publisher == null)
                throw new NotFoundException("Publisher not found.");

            return _mapper.Map<IEnumerable<GameResponseDto>>(publisher.Games);
        }
    }
}
