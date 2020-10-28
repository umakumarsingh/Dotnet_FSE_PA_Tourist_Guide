using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.Servies.Repository;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Servies
{
    public class TourguideServices : ITourguideServices
    {
        /// <summary>
        /// Creating referance variable of TourguideRepository and injecting in Constructor
        /// </summary>
        private readonly ITourguideRepository _tgRepository;

        public TourguideServices(ITourguideRepository tourguideRepository)
        {
            _tgRepository = tourguideRepository;
        }
        /// <summary>
        /// Get list of Destination fron MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public IList<Destination> DestinationList()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all place from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get place by destination by Destination Id
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Destination> GetPlaceByDestinationId(string destinationId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Place by Id from MongoDb  Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(string placeId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Hire Tour Guide by user
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> HireTourGuide(TourGuide tourGuide)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all information from AboutIndia MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AboutIndia>> KnowAboutIndia()
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// get place by Attraction from Place MongoDb collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> PlaceByAttraction(string name)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Tour Guide Infromation for user
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<TourGuide> TourGuideInformation(string tourId)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add Message by user in ContactsUs MongoDb Collection
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        public async Task<ContactUs> UserContactUs(ContactUs contactUs)
        {
            //Do Code Here
            throw new NotImplementedException();
        }
    }
}
