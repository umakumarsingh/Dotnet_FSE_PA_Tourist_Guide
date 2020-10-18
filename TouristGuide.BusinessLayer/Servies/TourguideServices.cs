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
            var destination = _tgRepository.DestinationList();
            return destination;
        }
        /// <summary>
        /// Get all place from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            var place = await _tgRepository.GetAllPlaces();
            return place;
        }
        /// <summary>
        /// Get place by destination by Destination Id
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Destination> GetPlaceByDestinationId(string destinationId)
        {
            var destination = await _tgRepository.GetPlaceByDestinationId(destinationId);
            return destination;
        }
        /// <summary>
        /// Get Place by Id from MongoDb  Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(string placeId)
        {
            var place = await _tgRepository.GetPlaceById(placeId);
            return place;
        }
        /// <summary>
        /// Hire Tour Guide by user
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> HireTourGuide(TourGuide tourGuide)
        {
            var tourguide = await _tgRepository.HireTourGuide(tourGuide);
            return tourGuide;
        }
        /// <summary>
        /// Get all information from AboutIndia MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AboutIndia>> KnowAboutIndia()
        {
            var about = await _tgRepository.KnowAboutIndia();
            return about;
        }
        /// <summary>
        /// get place by Attraction from Place MongoDb collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> PlaceByAttraction(string name)
        {
            var attraction = await _tgRepository.PlaceByAttraction(name);
            return attraction;
        }
        /// <summary>
        /// Get Tour Guide Infromation for user
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<TourGuide> TourGuideInformation(string tourId)
        {
            var guideinfo = await _tgRepository.TourGuideInformation(tourId);
            return guideinfo;
        }
        /// <summary>
        /// Add Message by user in ContactsUs MongoDb Collection
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        public async Task<ContactUs> UserContactUs(ContactUs contactUs)
        {
            var newcontact = await _tgRepository.UserContactUs(contactUs);
            return newcontact;
        }
    }
}
