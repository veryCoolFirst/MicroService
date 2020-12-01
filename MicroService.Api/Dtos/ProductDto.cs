using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Api.Dtos
{
    public class ProductDto
    {
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
        public string ProductName { get; set; }

        public int SerialNo { get; set; }
        public decimal Amt { get; set; }
        public string Address { get; set; }
        public DateTime EffectDate { get; set; } = DateTime.Now;
    }
}
