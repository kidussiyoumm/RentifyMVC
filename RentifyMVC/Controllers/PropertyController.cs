using Microsoft.AspNetCore.Mvc;
using Rentify.Models.Domains;
using RentifyMVC.Repository.Implementation;
using RentifyMVC.Repository.Interfaces;

namespace RentifyMVC.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly IProperty _propertyRepository;
        public PropertyController(IProperty _propertyRepository) {
            this._propertyRepository = _propertyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index() //Controler
        {
            var properties = await _propertyRepository.ListPropertyAsync(); //Data model

            return View(properties);//View
        }


        [HttpPost]

        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            try
            {
                if(property == null)
                {
                    throw new Exception("Please Try Again");
                }

                await _propertyRepository.CreatePropertyAsync(property);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


            return Ok();
        }
    }
}
