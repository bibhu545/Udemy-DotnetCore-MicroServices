using Mango.web.Models;
using Mango.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.web.Services.IServices
{
    public interface IBaseService:IDisposable
    {
        public ResponseDto responseModel { get; set; }
        Task<T> SendApiRequest<T>(ApiRequest request);
    }
}
