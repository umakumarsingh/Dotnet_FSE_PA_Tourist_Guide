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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Destination for user from Db Collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DestinationList")]
        public IActionResult GetDestinationList()
        {
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Know About India some Quick Information that featch from AboutIndia Db Collction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AboutIndia")]
        public async Task<IEnumerable<AboutIndia>> AboutIndia()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
