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
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// List of All Tour Guide who register with us.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllGuide")]
        public async Task<IEnumerable<TourGuide>> AllTourGuide()
        {
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
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
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
