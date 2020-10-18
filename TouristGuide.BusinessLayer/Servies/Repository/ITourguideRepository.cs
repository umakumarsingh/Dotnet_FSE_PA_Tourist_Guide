using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Servies.Repository
{
    public interface ITourguideRepository
    {
        Task<IEnumerable<Place>> GetAllPlaces();
        Task<Place> GetPlaceById(string placeId);
        Task<Destination> GetPlaceByDestinationId(string destinationId);
        Task<IEnumerable<Place>> PlaceByAttraction(string name);
        Task<TourGuide> HireTourGuide(TourGuide tourGuide);
        Task<IEnumerable<AboutIndia>> KnowAboutIndia();
        IList<Destination> DestinationList();
        Task<TourGuide> TourGuideInformation(string tourId);
        Task<ContactUs> UserContactUs(ContactUs contactUs);
    }
}
