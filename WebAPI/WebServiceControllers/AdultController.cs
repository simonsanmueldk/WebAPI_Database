using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.WebServiceControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdultController : Controller
    {
        private readonly ILogger<AdultController> _logger;
        private readonly IAdultService _adultService;

        public AdultController(ILogger<AdultController> logger,IAdultService adultService)
        {
            _logger = logger;
            _adultService = adultService;
        }

        [HttpGet]
        [Route("All")]
        public IList<Adult> GetAll()
        {
            return _adultService.ReadAllAdults();
            
        }


        [HttpPost]
        [Route("AddAdult")]
        public void AddAdult(Adult adult)
        {
            _adultService.AddAdult(adult);
        }

        [HttpPost]
        [Route("UpdateAdult")]
        public void UpdateAdult(Adult adult)
        {
            _adultService.UpdateAdult(adult);
        }

        [HttpPost]
        [Route("DeleteAdult")]
        public void DeleteAdult(Adult adult)
        {
            _adultService.DeleteAdult(adult);
        }
    }
}
