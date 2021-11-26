using CB_BusinessLogic.Services;
using CB_BusinessLogic.Services.GenericRepoEFCore;
using CB_DataEntity.GenericRepository;
using DataEntities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericRepoEFCoreController : ControllerBase
    {
        private IGenericRepoEFCoreService _IGenericRepoEFCoreService;
        public GenericRepoEFCoreController(IGenericRepoEFCoreService _IGenericRepoEFCoreService )
        {
            this._IGenericRepoEFCoreService = _IGenericRepoEFCoreService;
        }

        [Route("GetAllCustomer")]
        [HttpGet]
        public IActionResult GetAllByList()
        {
            var response = _IGenericRepoEFCoreService.GetAllByList();
            return Ok(response.ToList());
        }

        [Route("GetById")]
        [HttpPost]
        public IActionResult GetById(int id)
        {
            var response = _IGenericRepoEFCoreService.GetById(id);
            return Ok(response);
        }

        [Route("AddNew")]
        [HttpPost]
        public void AddNew(Customers obj)
        {
            _IGenericRepoEFCoreService.AddNew(obj);
          
        }

        [Route("Update")]
        [HttpPost]
        public void Update(Customers obj)
        {
            _IGenericRepoEFCoreService.Update(obj);

        }

        [Route("Delete")]
        [HttpPost]
        public void Delete(int id)
        {
            _IGenericRepoEFCoreService.Delete(id);

        }
    }
    }
