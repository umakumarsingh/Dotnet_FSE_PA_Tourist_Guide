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
    public class TouristController : ControllerBase
    {
        /// <summary>
        /// Creting Referance variable of ITourguideServices and injecting in Controller Constructor
        /// </summary>
        private readonly ITourguideServices _tgServices;

        public TouristController(ITourguideServices tourguideServices)
        {
            _tgServices = tourguideServices;
        }
        /// <summary>
        /// Get all Place for User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Place>> GetAllPlace()
        {
            return await _tgServices.GetAllPlaces();
        }
        /// <summary>
        /// Get a place Details by Place Id
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PlaceById/{placeId}")]
        public async Task<IActionResult> GetPlaceById(string placeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getplace = await _tgServices.GetPlaceById(placeId);
            if (getplace == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllPlace", new { placeId = getplace.PlaceId }, getplace);
        }
        /// <summary>
        /// Find Placce by Attraction and Place name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Findplace/{Name}")]
        public async Task<IActionResult> FindPlacebyAttraction(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var findplace = await _tgServices.PlaceByAttraction(name);
            if (findplace == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllPlace", findplace);
        }
        /// <summary>
        /// Hire a tour guide by user and save data in MongoDb collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("HireTourGuide")]
        public async Task<IActionResult> HireTourGuide([FromBody] TourGuideViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TourGuide guide = new TourGuide
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                Experience = model.Experience,
                Remark = model.Remark
            };
            var result = await _tgServices.HireTourGuide(guide);
            //return CreatedAtAction("TourGuideInformation", new { tourId = result.TourId }, result);
            return Ok("Thanks for Hiring Tour Guide We contact you Soon..");
        }
        /// <summary>
        /// Get all Destination for user from Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DestinationList")]
        public IActionResult GetDestinationList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getdestination = _tgServices.DestinationList();
            if (getdestination == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllPlace", getdestination);
        }
        /// <summary>
        /// get Tour guide information by TourId
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TourGuideInformation/{tourId}")]
        public async Task<IActionResult> TourGuideInformation(string tourId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var guideinfo = await _tgServices.TourGuideInformation(tourId);
            if (guideinfo == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetAllPlace", new { tourId = guideinfo.TourId}, guideinfo);
        }
        /// <summary>
        /// Conatct Us by User and save all message in ContactUs Db Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Contactus")]
        public async Task<IActionResult> ContactUs([FromBody] ContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContactUs message = new ContactUs
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Email = model.Email,
                Message = model.Message,
                DateofMessage = model.DateofMessage
            };
            var result = await _tgServices.UserContactUs(message);
            return Ok("Thanks for Contact with Us Tour Guide We contact you Soon..");
        }
        /// <summary>
        /// Know About India some Quick Information that featch from AboutIndia Db Collction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AboutIndia")]
        public async Task<IEnumerable<AboutIndia>> AboutIndia()
        {
            return await _tgServices.KnowAboutIndia();
        }
    }
}
