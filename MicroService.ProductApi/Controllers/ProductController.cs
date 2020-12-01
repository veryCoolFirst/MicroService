using MicroService.ProductApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MicroService.ProductApi.Controllers
{
    [Route("ProductApi/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IConfiguration _configuration;
        private static string ipAddress;
        public ProductController(ILogger<ProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            ipAddress = Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort;
        }

        private static List<ProductDto> products = new List<ProductDto>()
        {
            new ProductDto()
            {
                ProductName = "香蕉",
                Amt = 0.01m,
                SerialNo = 1,
                Address = ipAddress,

            },
            new ProductDto()
            {
                ProductName = "苹果",
                Amt = 0.02m,
                SerialNo = 1,
                Address = ipAddress,

            },
            new ProductDto()
            {
                ProductName = "梨子",
                Amt = 0.03m,
                SerialNo = 1,
                Address = ipAddress,

            }
        };
        [HttpGet,Route("get/{no}")]
        public async Task<ProductDto> Get(int no)
        {
            return await Task.FromResult(products.SingleOrDefault(m => m.SerialNo == no));
        }
        [HttpGet, Route("all")]
        public async Task<JsonResult> GetAll()
        {
            return await Task.FromResult(new JsonResult(products));
        }
    }
}
