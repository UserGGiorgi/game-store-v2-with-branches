using GameStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentResults
{
    public class BankPaymentResult : PaymentResult
    {
        public byte[] PdfContent { get; set; }
        public string FileName { get; set; }
    }
}
