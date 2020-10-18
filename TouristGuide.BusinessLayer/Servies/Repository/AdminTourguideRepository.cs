using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.DataLayer;
using TouristGuide.Entities;

namespace TouristGuide.BusinessLayer.Servies.Repository
{
    public class AdminTourguideRepository : IAdminTourguideRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Place> _dbPCollection;
        private IMongoCollection<ContactUs> _dbCCollection;
        private IMongoCollection<TourGuide> _dbTCollection;
        private IMongoCollection<Destination> _dbDCollection;
        private IMongoCollection<AboutIndia> _dbACollection;
        public AdminTourguideRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbPCollection = _mongoContext.GetCollection<Place>(typeof(Place).Name);
            _dbCCollection = _mongoContext.GetCollection<ContactUs>(typeof(ContactUs).Name);
            _dbTCollection = _mongoContext.GetCollection<TourGuide>(typeof(TourGuide).Name);
            _dbDCollection = _mongoContext.GetCollection<Destination>(typeof(Destination).Name);
            _dbACollection = _mongoContext.GetCollection<AboutIndia>(typeof(AboutIndia).Name);
        }
        /// <summary>
        /// Get all Information about india from AboutIndia MongoDb Collection
        /// </summary>
        /// <param name="aboutIndia"></param>
        /// <returns></returns>
        public async Task<AboutIndia> AboutIndia(AboutIndia aboutIndia)
        {
            try
            {
                if (aboutIndia == null)
                {
                    throw new ArgumentNullException(typeof(AboutIndia).Name + "Object is Null");
                }
                _dbACollection = _mongoContext.GetCollection<AboutIndia>(typeof(AboutIndia).Name);
                await _dbACollection.InsertOneAsync(aboutIndia);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return aboutIndia;
        }
        /// <summary>
        /// add new Destination in MongoDb Destination Collection
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Destination> AddNewDestination(Destination destination)
        {
            try
            {
                if (destination == null)
                {
                    throw new ArgumentNullException(typeof(Destination).Name + "Object is Null");
                }
                _dbDCollection = _mongoContext.GetCollection<Destination>(typeof(Destination).Name);
                await _dbDCollection.InsertOneAsync(destination);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return destination;
        }
        /// <summary>
        /// add new Place in MongoDb Place Collection
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public async Task<Place> AddNewPlace(Place place)
        {
            try
            {
                if (place == null)
                {
                    throw new ArgumentNullException(typeof(Place).Name + "Object is Null");
                }
                _dbPCollection = _mongoContext.GetCollection<Place>(typeof(Place).Name);
                await _dbPCollection.InsertOneAsync(place);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return place;
        }
        /// <summary>
        /// Get all Information of Contact Message come from User in MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContactUs>> AllContactMessage()
        {
            try
            {
                var list = _mongoContext.GetCollection<ContactUs>("ContactUs")
                .Find(Builders<ContactUs>.Filter.Empty, null)
                .SortByDescending(e => e.DateofMessage);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all tour guide information from TourGuide Mongodb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TourGuide>> AllTourGuide()
        {
            try
            {
                var list = _mongoContext.GetCollection<TourGuide>("TourGuide")
                .Find(Builders<TourGuide>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete Destination information from Destination by Id Mongodb Collection
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDestination(string destinationId)
        {
            try
            {
                var objectId = new ObjectId(destinationId);
                FilterDefinition<Destination> filter = Builders<Destination>.Filter.Eq("DestinationId", objectId);
                var result = await _dbDCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete Place information from Place by Id Mongodb Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<bool> DeletePlace(string placeId)
        {
            try
            {
                var objectId = new ObjectId(placeId);
                FilterDefinition<Place> filter = Builders<Place>.Filter.Eq("PlaceId", objectId);
                var result = await _dbPCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete Tour Guide information from TourGuide by Id Mongodb Collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteTourGuide(string tourId)
        {
            try
            {
                var objectId = new ObjectId(tourId);
                FilterDefinition<TourGuide> filter = Builders<TourGuide>.Filter.Eq("TourId", objectId);
                var result = await _dbTCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Destination By destinationId
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Destination> DestinationById(string destinationId)
        {
            try
            {
                var objectId = new ObjectId(destinationId);
                FilterDefinition<Destination> filter = Builders<Destination>.Filter.Eq("DestinationId", objectId);
                _dbDCollection = _mongoContext.GetCollection<Destination>(typeof(Destination).Name);
                return await _dbDCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Get TourGuide Infromation by Id from TourGuide MongoDb collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<TourGuide> TourGuideById(string tourId)
        {
            try
            {
                var objectId = new ObjectId(tourId);
                FilterDefinition<TourGuide> filter = Builders<TourGuide>.Filter.Eq("tourId", objectId);
                _dbTCollection = _mongoContext.GetCollection<TourGuide>(typeof(TourGuide).Name);
                return await _dbTCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Update an existing Destination by destinationId
        /// </summary>
        /// <param name="destinationId"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Destination> UpdateDestination(string destinationId, Destination destination)
        {
            if (destination == null && destinationId == null)
            {
                throw new ArgumentNullException(typeof(Destination).Name + "Object or may be destinationId is Null");
            }
            var update = await _dbDCollection.FindOneAndUpdateAsync(Builders<Destination>.
                Filter.Eq("DestinationId", destination.DestinationId), Builders<Destination>.
                Update.Set("Name", destination.Name).Set("Url", destination.Url).Set("OpenInNewWindow", destination.OpenInNewWindow)
                .Set("Description", destination.Description));
            return update;
        }
        /// <summary>
        /// Update an existing Place by PlaceId
        /// </summary>
        /// <param name="placeId"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        public async Task<Place> UpdatePlace(string placeId, Place place)
        {
            if (place == null && placeId == null)
            {
                throw new ArgumentNullException(typeof(Place).Name + "Object or may be PlaceId is Null");
            }
            var update = await _dbPCollection.FindOneAndUpdateAsync(Builders<Place>.
                Filter.Eq("PlaceId", place.PlaceId), Builders<Place>.
                Update.Set("Name", place.Name).Set("Picture", place.Picture).Set("Description", place.Description)
                .Set("Attraction", place.Attraction).Set("Experiences", place.Experiences).Set("Distance", place.Distance)
                .Set("DestinationId", place.DestinationId));
            return update;
        }
        /// <summary>
        /// Update TourGuide Information Using tourId
        /// </summary>
        /// <param name="tourId"></param>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> UpdateTourGuide(string tourId, TourGuide tourGuide)
        {
            if (tourGuide == null && tourId == null)
            {
                throw new ArgumentNullException(typeof(TourGuide).Name + "Object or may be TourId is Null");
            }
            var update = await _dbTCollection.FindOneAndUpdateAsync(Builders<TourGuide>.
                Filter.Eq("TourId", tourGuide.TourId), Builders<TourGuide>.
                Update.Set("Name", tourGuide.Name).Set("Phone", tourGuide.Phone).Set("Email", tourGuide.Email)
                .Set("Address", tourGuide.Address).Set("Experience", tourGuide.Experience).Set("Remark", tourGuide.Remark));
            return update;
        }
    }
}
