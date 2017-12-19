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
    public class LabOrderListController : ApiController
    {
       
        // GET: api/LabOrderList
        public async Task<List<LabOrderListViewModel>> Get()
        {
            var service = new LabOrderService();
            //TODO:Complete service implementation
            var result = await service.GetLabOrderList();
            return result;
        }

    }
}
