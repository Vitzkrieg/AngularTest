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
            var result = await service.GetLabOrderDetail(id);
            return result;
        }

        // POST: api/saveLabOrderDetail
        //[Route("api/saveLabOrderDetail/{id}/{amount}")]
        [HttpPost]
        public async Task<LabOrderDetailResultModel> Post(LabOrderDetailSaveModel data)
        {
            var service = new LabOrderDetailService();
            var saveResult = await service.SaveLabOrderDetail(data.Id, data.AmountCollected);
            LabOrderDetailResultModel resultObj = new LabOrderDetailResultModel();
            resultObj.result = saveResult;
            return resultObj;
        }

    }
}
