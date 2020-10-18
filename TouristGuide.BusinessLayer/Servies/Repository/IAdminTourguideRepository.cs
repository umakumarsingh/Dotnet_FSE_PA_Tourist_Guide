using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Servies.Repository
{
    public interface IAdminTourguideRepository
    {
        Task<IEnumerable<TourGuide>> AllTourGuide();
        Task<IEnumerable<ContactUs>> AllContactMessage();
        Task<TourGuide> TourGuideById(string tourId);
        Task<TourGuide> UpdateTourGuide(string tourId, TourGuide tourGuide);
        Task<Place> AddNewPlace(Place place);
        Task<Place> UpdatePlace(string placeId, Place place);
        Task<Destination> AddNewDestination(Destination destination);
        Task<Destination> DestinationById(string destinationId);
        Task<Destination> UpdateDestination(string destinationId, Destination destination);
        Task<AboutIndia> AboutIndia(AboutIndia aboutIndia);
        Task<bool> DeleteTourGuide(string tourId);
        Task<bool> DeletePlace(string placeId);
        Task<bool> DeleteDestination(string destinationId);
    }
}
