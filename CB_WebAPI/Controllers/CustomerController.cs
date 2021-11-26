using AF.DataEntities.Context;
using CB_BusinessLogic.Services;
using CB_BusinessLogic.Services.CustomerService;
using DataEntities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB_WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly IMainService _IMainService;

        public CustomerController(IMainService IMainService)
        {
            _IMainService = IMainService;
           
        }
        // Dapper SP
        [Route("GetAllCustomersSpDapper")]
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_IMainService.GetAllCustomers());
        }

        // Dapper SP
        [Route("PostCustomersSpDapper")]
        [HttpPost]
        public IActionResult PostCustomers(CustomersRequest obj)
        {
            return Ok(_IMainService.PostCustomers(obj));
        }

      

    }
}
