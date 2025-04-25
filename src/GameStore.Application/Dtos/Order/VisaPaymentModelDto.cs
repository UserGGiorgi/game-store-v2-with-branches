using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order
{
    public class VisaPaymentModelDto
    {
        [Required]
        public string Holder { get; set; }

        [Required, CreditCard]
        public string CardNumber { get; set; }

        [Required, Range(1, 12)]
        public int MonthExpire { get; set; }

        [Required, Range(2023, 2100)]
        public int YearExpire { get; set; }

        [Required, Range(100, 9999)]
        public int Cvv2 { get; set; }
    }
}
