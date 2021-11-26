using CB_BusinessLogic.Services;
using CB_BusinessLogic.Services.CustomerService;
using CB_BusinessLogic.Services.EfCoreCrud;
using CB_DataEntity.Context;
using DataEntities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB_WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EfCoreCrudController : ControllerBase
    {
        private readonly IMainService _IMainService;
        public EfCoreCrudController(
                                     IMainService iMainService)
        {
            _IMainService = iMainService;
        }
        
        [Route("GetCustomersList")]
        [HttpGet]
        public IActionResult GetCustomersList()
        {
            return Ok(_IMainService.GetCustomersList());
        }

        [Route("GetCustomersById")]
        [HttpPost]
        public IActionResult GetCustomersById(int id)
        {
            return Ok(_IMainService.GetCustomersById(id));
        }

        [Route("InsertCustomers")]
        [HttpPost]
        public void InsertCustomers(Customers obj)
        {
            _IMainService.InsertCustomer(obj);
        }

        [Route("UpdateCustomers")]
        [HttpPost]
        public void UpdateCustomers(Customers obj)
        {
            _IMainService.UpdateCustomer(obj);
        }
        
        [Route("DeleteCustomers")]
        [HttpPost]
        public void DeleteCustomers(int id)
        {
            _IMainService.DeleteCustomer(id);
        }
    }
}
