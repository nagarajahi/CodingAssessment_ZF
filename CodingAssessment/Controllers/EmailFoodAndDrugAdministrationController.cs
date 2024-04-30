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
    public class EmailFoodAndDrugAdministrationController : ControllerBase
    {
        private readonly IEmailService _iEmailService;

        public EmailFoodAndDrugAdministrationController(IEmailService iEmailService)
        {
            _iEmailService = iEmailService;
        }
        [Route("SendEmail")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Getlistoffoodenforcementandsendemail()
        {
            string url = "https://api.fda.gov/food/enforcement.json?limit=10";

            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            Food? myDeserializedClass = JsonConvert.DeserializeObject<Food>(response.Content.ReadAsStringAsync().Result);

            var result = await _iEmailService.SendEmailAsync(myDeserializedClass);

            return Ok(result);
        }
    }
}