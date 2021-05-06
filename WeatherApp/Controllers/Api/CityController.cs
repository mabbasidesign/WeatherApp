using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Dtos;

namespace WeatherApp.Controllers.Api
{
    [Route("api/City")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        //api/city
        [ProducesResponseType(200, Type = typeof(IEnumerable<CityDtos>))]
        [ProducesResponseType(400)]
        public IActionResult GetCities()
        {
            var cities = _cityRepository.GetCities();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var citiesDtos = new List<CityDtos>();

            foreach(var city in cities)
            {
                citiesDtos.Add(new CityDtos
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    Latitude = city.Latitude,
                    Longitude = city.Longitude,
                    ZipCode = city.ZipCode
                });
            }

            return Ok(citiesDtos);
        }

        //api/city/cityId
        [HttpGet("{cityId}", Name = "GetCity")]
        [ProducesResponseType(200, Type = typeof(CityDtos))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCity(int cityId)
        {
            var city = _cityRepository.GetCity(cityId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityDtos = new CityDtos()
            {
                Id = city.Id,
                CityName = city.CityName,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                ZipCode = city.ZipCode
            };
            
            return Ok(cityDtos);
        }

        //api/city
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(City))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateCity([FromBody] City cityToCreate)
        {
            if (cityToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cityRepository.CreateCity(cityToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the city of" +
                    $"{cityToCreate.CityName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetCity", new { cityId = cityToCreate.Id}, cityToCreate);
        }

        //api/city/cityId
        [HttpPut("{cityId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCity(int cityId,[FromBody] City cityToUpdate)
        {
            if (cityToUpdate == null)
                return BadRequest(ModelState);

            if (cityId != cityToUpdate.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return StatusCode(404, ModelState);

            if (!_cityRepository.UpdateCity(cityToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the city of" +
                    $"{cityToUpdate.CityName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/city/cityId
        [HttpDelete("{cityId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCity(int cityId)
        {
            var cityToDelete = _cityRepository.GetCity(cityId);
    
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cityRepository.DeleteCity(cityToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                                            $"{cityToDelete.CityName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
