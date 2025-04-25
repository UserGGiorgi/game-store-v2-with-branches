using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order
{
    public class PaymentRequestDto
    {
        [Required]

        public string Method { get; set; }

        public VisaPaymentModelDto Model { get; set; }
    }
}
