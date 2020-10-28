using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.Servies.Repository;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Servies
{
    public class AdminTourguideServices : IAdminTourguideServices
    {
        /// <summary>
        /// Creating Referance variable of IAdminTourguideServices and injecting its variable into
        /// AdminTourguideServices constructor to call
        /// </summary>
        private readonly IAdminTourguideRepository _aTRepository;

        public AdminTourguideServices(IAdminTourguideRepository adminTourguideRepository)
        {
            _aTRepository = adminTourguideRepository;
        }
        /// <summary>
        /// Get all Information about india from AboutIndia MongoDb Collection
        /// </summary>
        /// <param name="aboutIndia"></param>
        /// <returns></returns>
        public async Task<AboutIndia> AboutIndia(AboutIndia aboutIndia)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// add new Destination in MongoDb Destination Collection
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Destination> AddNewDestination(Destination destination)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// add new Place in MongoDb Place Collection
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public async Task<Place> AddNewPlace(Place place)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Information of Contact Message come from User in MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactUs>> AllContactMessage()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all tour guide information from TourGuide Mongodb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TourGuide>> AllTourGuide()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Destination information from Destination by Id Mongodb Collection
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDestination(string destinationId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Place information from Place by Id Mongodb Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<bool> DeletePlace(string placeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Tour Guide information from TourGuide by Id Mongodb Collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTourGuide(string tourId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get destination by destinationId
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Destination> DestinationById(string destinationId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get TourGuide Infromation by Id from TourGuide MongoDb collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<TourGuide> TourGuideById(string tourId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Destination by destinationId
        /// </summary>
        /// <param name="destinationId"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Destination> UpdateDestination(string destinationId, Destination destination)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Place by PlaceId
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        public async Task<Place> UpdatePlace(string placeId, Place place)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update TourGuide Information Using tourId
        /// </summary>
        /// <param name="tourId"></param>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> UpdateTourGuide(string tourId, TourGuide tourGuide)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
