using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Models.DTO
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public object data { get; set; }
        public string message { get; set; } = "";
        public List<string> errorMessages { get; set; }
    }
}
