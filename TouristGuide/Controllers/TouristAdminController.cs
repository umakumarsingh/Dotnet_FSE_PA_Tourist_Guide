using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.ViewModel;
using TouristGuide.Entities;

namespace TouristGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristAdminController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminTourguideServices and injecting in Controller
        /// </summary>
        private readonly IAdminTourguideServices _atgServices;
        private readonly ITourguideServices _tgServices;

        public TouristAdminController(IAdminTourguideServices adminTourguideServices, ITourguideServices tourguideServices)
        {
            _atgServices = adminTourguideServices;
            _tgServices = tourguideServices;
        }
        /// <summary>
        /// Get list of Message by User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ContactUs>> MessagebyUser()
        {
            return await _atgServices.AllContactMessage();
        }
        /// <summary>
        /// List of All Tour Guide who register with us.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllGuide")]
        public async Task<IEnumerable<TourGuide>> AllTourGuide()
        {
            return await _atgServices.AllTourGuide();
        }
        /// <summary>
        /// Update an existing tour Operator by its Id and TourGuide Collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTourGuide/{tourId}")]
        public async Task<IActionResult> UpdateTourGuide(string tourId, [FromBody] TourGuide tourGuide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getTour = _atgServices.TourGuideById(tourId);
            if (getTour == null)
            {
                return NotFound();
            }
            await _atgServices.UpdateTourGuide(tourId, tourGuide);
            return CreatedAtAction("AllTourGuide", new { tourId = tourGuide.TourId }, tourGuide);
        }
        /// <summary>
        /// Delete an Existing tour guide by tourId
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTourGuide/{tourId}")]
        public async Task<IActionResult> DeleteTourGuide(string tourId)
        {
            if (tourId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _atgServices.DeleteTourGuide(tourId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Tour Guide Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Add new Place in MongoDb Place Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewPlace")]
        public async Task<IActionResult> AddPlace([FromBody] PlaceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Place newPlace = new Place
            {
                Name = model.Name,
                Picture = model.Picture,
                Description = model.Description,
                Attraction = model.Attraction,
                Experiences = model.Experiences,
                Distance = model.Distance,
                DestinationId = model.DestinationId
            };
            var result = await _atgServices.AddNewPlace(newPlace);
            return Ok("New Place added...");
        }
        /// <summary>
        /// Update an Existing Place and add some information
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdatePlace/{placeId}")]
        public async Task<IActionResult> UpdatePlace(string placeId, [FromBody]  Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getPlace = _tgServices.GetPlaceById(placeId);
            if (getPlace == null)
            {
                return NotFound();
            }
            await _atgServices.UpdatePlace(placeId, place);
            return CreatedAtAction("GetAllPlace","Tourist", new { placeId = place.PlaceId }, place);
        }
        /// <summary>
        /// Delete a place from MongoDb Place Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePlace/{placeId}")]
        public async Task<IActionResult> DeletePlace(string placeId)
        {
            if (placeId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _atgServices.DeletePlace(placeId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Place Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Add new Destination in destination MongoDb Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NewDestination")]
        public async Task<IActionResult> AddNewDestination([FromBody] DestinationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Destination destination = new Destination
            {
                Name = model.Name,
                Url = model.Url,
                OpenInNewWindow = model.OpenInNewWindow,
                Description = model.Description
            };
            var result = await _atgServices.AddNewDestination(destination);
            return Ok("New Destination added...");
        }
        /// <summary>
        /// Update an Existing Destination
        /// </summary>
        /// <param name="destiationId"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateDestination/{destinationId}")]
        public async Task<IActionResult> UpdateDestination(string destiationId, [FromBody] Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getdestiation = _atgServices.DestinationById(destiationId);
            if (getdestiation == null)
            {
                return NotFound();
            }
            await _atgServices.UpdateDestination(destiationId, destination);
            return CreatedAtAction("GetDestinationList", "Tourist", new { destinationId = destination.DestinationId }, destination);
        }
        /// <summary>
        /// Delete an existing Destination by destinationId
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteDestination/{destinationId}")]
        public async Task<IActionResult> DeleteDestination(string destinationId)
        {
            if (destinationId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _atgServices.DeleteDestination(destinationId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Destination Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Add information About India
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AboutIndia")]
        public async Task<IActionResult> AddAboutIndia([FromBody] AboutIndiaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AboutIndia abouindia = new AboutIndia
            {
                About = model.About,
                Visa = model.Visa,
                Currency = model.Currency,
                Language = model.Language,
                State = model.State,
                UNION_TERRITORIES =  model.UNION_TERRITORIES,
                Climate = model.Climate,
                How_Visit =  model.How_Visit

            };
            await _atgServices.AboutIndia(abouindia);
            return Ok("About India Information added...");
        }
    }
}
