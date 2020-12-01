using MicroService.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
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

namespace MicroService.Api.Controllers
{
    [Route("api/[controller]")]
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
            ipAddress = _configuration["ip"] + ":" + _configuration["port"];
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
                SerialNo = 2,
                Address = ipAddress,

            },
            new ProductDto()
            {
                ProductName = "梨子",
                Amt = 0.03m,
                SerialNo = 3,
                Address = ipAddress,

            }
        };
        [Authorize]
        [HttpGet,Route("get/{no:int}")]
        public async Task<ProductDto> GetAsync(int no)
        {
            return await Task.FromResult(products.FirstOrDefault(m => m.SerialNo == no));
        }
        [AllowAnonymous]
        [HttpGet, Route("all")]
        public async Task<List<ProductDto>> GetAll()
        {
            return await Task.FromResult(products);
        }
        [HttpGet, Route("ip")]
        public string GetIp()
        {
            return _configuration["ip"] + ":" + _configuration["port"];
        }
    }
}
