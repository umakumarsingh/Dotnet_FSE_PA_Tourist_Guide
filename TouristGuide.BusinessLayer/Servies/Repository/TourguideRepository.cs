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
    public class TourguideRepository : ITourguideRepository
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
        public TourguideRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbPCollection = _mongoContext.GetCollection<Place>(typeof(Place).Name);
            _dbCCollection = _mongoContext.GetCollection<ContactUs>(typeof(ContactUs).Name);
            _dbTCollection = _mongoContext.GetCollection<TourGuide>(typeof(TourGuide).Name);
            _dbDCollection = _mongoContext.GetCollection<Destination>(typeof(Destination).Name);
            _dbACollection = _mongoContext.GetCollection<AboutIndia>(typeof(AboutIndia).Name);
        }
        /// <summary>
        /// Get list of Destination for Menubar
        /// </summary>
        /// <returns></returns>
        public IList<Destination> DestinationList()
        {
            try
            {
                var list = _mongoContext.GetCollection<Destination>("Destination")
                .Find(Builders<Destination>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get List of visiting Place
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            try
            {
                var list = _mongoContext.GetCollection<Place>("Place")
                .Find(Builders<Place>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Place by Destination Id from MongoDb Collection
        /// </summary>
        /// <param name="destinationId"></param>
        /// <returns></returns>
        public async Task<Destination> GetPlaceByDestinationId(string destinationId)
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
        /// Get place by Id from Mongodb Collection
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        public async Task<Place> GetPlaceById(string placeId)
        {
            try
            {
                var objectId = new ObjectId(placeId);
                FilterDefinition<Place> filter = Builders<Place>.Filter.Eq("PlaceId", objectId);
                _dbPCollection = _mongoContext.GetCollection<Place>(typeof(Place).Name);
                return await _dbPCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Hire Tour Guide for Assistance
        /// </summary>
        /// <param name="tourGuide"></param>
        /// <returns></returns>
        public async Task<TourGuide> HireTourGuide(TourGuide tourGuide)
        {
            try
            {
                if (tourGuide == null)
                {
                    throw new ArgumentNullException(typeof(TourGuide).Name + "Object is Null");
                }
                _dbTCollection = _mongoContext.GetCollection<TourGuide>(typeof(TourGuide).Name);
                await _dbTCollection.InsertOneAsync(tourGuide);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return tourGuide;
        }
        /// <summary>
        /// Know about india information from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AboutIndia>> KnowAboutIndia()
        {
            try
            {
                var list = _mongoContext.GetCollection<AboutIndia>("AboutIndia")
                .Find(Builders<AboutIndia>.Filter.Empty, null)
                .SortByDescending(e => e.Id);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// get place by attraction and place name from Mongo Collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Place>> PlaceByAttraction(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Place>();
                var findName = filterBuilder.Eq(s => s.Name, name);
                var findAttraction = filterBuilder.Eq(s => s.Attraction, name.ToString());
                _dbPCollection = _mongoContext.GetCollection<Place>(typeof(Place).Name);
                var result = await _dbPCollection.FindAsync(findName | findAttraction).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Tour Guide Information form MongoDb Collection
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        public async Task<TourGuide> TourGuideInformation(string tourId)
        {
            try
            {
                var objectId = new ObjectId(tourId);
                FilterDefinition<TourGuide> filter = Builders<TourGuide>.Filter.Eq("TourId", objectId);
                _dbTCollection = _mongoContext.GetCollection<TourGuide>(typeof(TourGuide).Name);
                return await _dbTCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Add new Contact us Message by User
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        public async Task<ContactUs> UserContactUs(ContactUs contactUs)
        {
            try
            {
                if (contactUs == null)
                {
                    throw new ArgumentNullException(typeof(ContactUs).Name + "Object is Null");
                }
                _dbCCollection = _mongoContext.GetCollection<ContactUs>(typeof(ContactUs).Name);
                await _dbCCollection.InsertOneAsync(contactUs);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return contactUs;
        }
    }
}
