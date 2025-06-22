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
        public string Method { get; set; } = string.Empty;

        public VisaPaymentModelDto Model { get; set; }  = new ();
    }

}
