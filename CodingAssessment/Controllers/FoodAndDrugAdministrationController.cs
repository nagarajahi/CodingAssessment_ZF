using CodingAssessment.Models;
using CodingAssessment.Repository.IRepository;
using CodingAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace CodingAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodAndDrugAdministrationController : ControllerBase
    {
        private readonly ILogger<FoodAndDrugAdministrationController> _logger; 

        private readonly IFoodAndDrugAdministrationRepository _foodAndDrugAdministrationRepository;
        public FoodAndDrugAdministrationController(IFoodAndDrugAdministrationRepository foodAndDrugAdministrationRepository, ILogger<FoodAndDrugAdministrationController> logger)
        {
            _foodAndDrugAdministrationRepository = foodAndDrugAdministrationRepository;
            _logger = logger;
        }

        [Route("Foodenforcement/Process")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Processlistoffoodenforcement(CancellationToken cancellationToken=default)
        {
            string url = "https://api.fda.gov/food/enforcement.json?limit=100";

            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            FoodInfo? myDeserializedClass = JsonConvert.DeserializeObject<FoodInfo>(response.Content.ReadAsStringAsync().Result);
           var result= await _foodAndDrugAdministrationRepository.InsertFoodAndDrug(myDeserializedClass, cancellationToken);
            return Ok(result);
        }
        [Route("Foodenforcement")]
        [HttpGet]
        [ProducesResponseType(typeof(FoodInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Getlistoffoodenforcement([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("fetch list of foodenforcement");
            var foodAndDrugList =await _foodAndDrugAdministrationRepository.GetAllFoodAndDrug(pageNumber, pageSize);
            return Ok(foodAndDrugList);
        }
    }
}