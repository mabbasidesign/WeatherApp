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
    [Route("api/Hourly")]
    [ApiController]
    public class HourlyController : Controller
    {
        private readonly IHourlyRepository _hourlyRepository;
        public HourlyController(IHourlyRepository hourlyRepository)
        {
            _hourlyRepository = hourlyRepository;
        }

        //api/hourly
        [ProducesResponseType(200, Type = typeof(IEnumerable<HourlyDtos>))]
        [ProducesResponseType(400)]
        public IActionResult GetHourlies()
        {
            var hourlies = _hourlyRepository.GetHorlyWeathers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hourlyDtos = new List<HourlyDtos>();

            foreach (var hourly in hourlies)
            {
                hourlyDtos.Add(new HourlyDtos
                {
                    Id = hourly.Id,
                    Humidity = hourly.Humidity,
                    Temperature = hourly.Temperature,
                    WindSpeed = hourly.WindSpeed
                });
            }

            return Ok(hourlyDtos);
        }

        //api/hourly/hourlyId
        [HttpGet("{hourlyId}", Name = "GetHourly")]
        [ProducesResponseType(200, Type = typeof(HourlyDtos))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetHourly(int hourlyId)
        {
            var hourly = _hourlyRepository.GetHorlyWeather(hourlyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hourlyDtos = new HourlyDtos()
            {
                Id = hourly.Id,
                Humidity = hourly.Humidity,
                Temperature = hourly.Temperature,
                WindSpeed = hourly.WindSpeed
            };

            return Ok(hourlyDtos);
        }

        //api/hourly?hourlyId=1&houryId=2
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Hourly))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateHourly([FromQuery] List<int> cityId, [FromBody] Hourly hourlyToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_hourlyRepository.CreateHorlyWeather(cityId, hourlyToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the hourly weather");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetHourly", new { hourlyId = hourlyToCreate.Id }, hourlyToCreate);
        }

        //api/hourly/hourlyId?cityId=1&cityId=2
        [HttpPut("{hourlyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdatHourly(int hourlyId, [FromQuery] List<int> cityId, [FromBody] Hourly hourlyToUpdate)
        {
            if (hourlyId != hourlyToUpdate.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_hourlyRepository.UpdateHorlyWeather(cityId, hourlyToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the hourly weather");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/hourly/hourlyId
        [HttpDelete("{hourlyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteHourly(int hourlyId)
        {
            var hourlyToDelete = _hourlyRepository.GetHorlyWeather(hourlyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_hourlyRepository.DeletHorlyWeather(hourlyToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting hourly weather");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
