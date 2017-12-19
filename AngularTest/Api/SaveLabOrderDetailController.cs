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
    public class SaveLabOrderDetailController : ApiController
    {
        // POST: api/saveLabOrderDetail
        [Route("api/saveLabOrderDetail")]
        public async Task<Boolean> Post(int id, decimal amountCollected)
        {
            var service = new LabOrderDetailService();
            System.Diagnostics.Debug.WriteLine("Post() id: " + id);
            bool result = await service.SaveLabOrderDetail(id, amountCollected);
            System.Diagnostics.Debug.WriteLine("Post() result: " + result);
            return result;
        }

    }
}
