using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AngularTest.Models;
using AngularTest.Services;

namespace AngularTest.Api
{
    public class LabOrderDetailController : ApiController
    {

        // GET: api/labOrderDetail
        [Route("api/labOrderDetail/{id}")]
        public async Task<LabOrderDetailViewModel> Get(int id)
        {
            var service = new LabOrderDetailService();
            System.Diagnostics.Debug.WriteLine("Get() id: " + id);
            var result = await service.GetLabOrderDetail(id);
            System.Diagnostics.Debug.WriteLine("Get() result: " + result);
            return result;
        }

    }
}
