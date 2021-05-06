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
    [Route("api/Daily")]
    [ApiController]
    public class DailyController : Controller
    {
        private readonly IDailyRepository _dailyRepository;
        public DailyController(IDailyRepository dailyRepository)
        {
            _dailyRepository = dailyRepository;
        }

        //api/daily
        [ProducesResponseType(200, Type = typeof(IEnumerable<DailyDtos>))]
        [ProducesResponseType(400)]
        public IActionResult GetDailies()
        {
            var dailies = _dailyRepository.GetDailyWeathers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dailiesDtos = new List<DailyDtos>();

            foreach (var daily in dailies)
            {
                dailiesDtos.Add(new DailyDtos
                {
                    Id = daily.Id,
                    Date = daily.Date,
                    MinTemperaure = daily.MinTemperaure,
                    MaxTemperature = daily.MaxTemperature,
                    Situation = daily.Situation,
                    WindSpeed = daily.WindSpeed,
                    SunriseTime = daily.SunriseTime,
                    SunetTime = daily.SunetTime,
                    LastUpdatedAt = daily.LastUpdatedAt
                });
            }

            return Ok(dailiesDtos);
        }

        //api/daily/dailyId
        [HttpGet("{dailyId}", Name = "GetDaily")]
        [ProducesResponseType(200, Type = typeof(DailyDtos))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetDaily(int dailyId)
        {
            var daily = _dailyRepository.GetDailyWeather(dailyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dailyDtos = new DailyDtos()
            {
                Id = daily.Id,
                Date = daily.Date,
                MinTemperaure = daily.MinTemperaure,
                MaxTemperature = daily.MaxTemperature,
                Situation = daily.Situation,
                WindSpeed = daily.WindSpeed,
                SunriseTime = daily.SunriseTime,
                SunetTime = daily.SunetTime,
                LastUpdatedAt = daily.LastUpdatedAt
            };

            return Ok(dailyDtos);
        }

        //api/daily?cityId=1&cityId=2
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Daily))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateDaily([FromQuery] List<int> cityId, [FromBody] Daily dailyToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_dailyRepository.CreateDailyWeather(cityId, dailyToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the weather");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetDaily", new { dailyId = dailyToCreate.Id }, dailyToCreate);
        }

        //api/daily/dailyId?cityId=1&cityId=2
        [HttpPut("{dailyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdateDaily(int dailyId, [FromQuery] List<int> cityId, [FromBody] Daily dailyToUpdate)
        {
            if (dailyId != dailyToUpdate.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_dailyRepository.UpdateDailyWeather(cityId, dailyToUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong updating the weather");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/daily/dailyId
        [HttpDelete("{dailyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteDaily(int dailyId)
        {
            var dailyToDelete = _dailyRepository.GetDailyWeather(dailyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_dailyRepository.DeleteDailyWeather(dailyToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting daily weather");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
