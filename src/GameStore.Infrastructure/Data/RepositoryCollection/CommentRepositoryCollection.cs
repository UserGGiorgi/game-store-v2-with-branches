using GameStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.RepositoryCollection
{
    public class CommentRepositoryCollection
    {
        public Lazy<ICommentBanRepository> CommentBan { get; }
        public Lazy<ICommentRepository> Comment { get; }
        public Lazy<IPublisherRepository> Publishers { get; }

        public CommentRepositoryCollection(
            Lazy<ICommentRepository> comment,
            Lazy<ICommentBanRepository> commentBan,
            Lazy<IPublisherRepository> publishers)
        {
            Comment = comment;
            CommentBan = commentBan;
            Publishers = publishers;
        }
    }
}
