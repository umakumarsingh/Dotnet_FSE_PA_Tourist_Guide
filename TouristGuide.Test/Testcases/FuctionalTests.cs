using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.BusinessLayer.Interfaces;
using TouristGuide.BusinessLayer.Servies;
using TouristGuide.BusinessLayer.Servies.Repository;
using TouristGuide.Entities;
using Xunit;

namespace TouristGuide.Test.Testcases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance of all Service Interfaces and Mocking All Repository
        /// </summary>
        private readonly IAdminTourguideServices _adminTS;
        private readonly ITourguideServices _tourGS;
        public readonly Mock<IAdminTourguideRepository> adminService = new Mock<IAdminTourguideRepository>();
        public readonly Mock<ITourguideRepository> tourService = new Mock<ITourguideRepository>();
        private AboutIndia _aboutIndia;
        private ContactUs _contactUs;
        private Destination _destination;
        private Place _place;
        private TourGuide _tourGuide;
        public FuctionalTests()
        {
            _adminTS = new AdminTourguideServices(adminService.Object);
            _tourGS = new TourguideServices(tourService.Object);
            _contactUs = new ContactUs()
            {
                ContactId = "5f8c4b27d90e94643c8a402e",
                FullName = "Kumar Uma",
                Phone = 9631438113,
                Email = "kumarumasingh@iiht.co.in",
                Message = "Call me need to how to book a Tour Guide",
                DateofMessage = DateTime.Now
            };
            _place = new Place()
            {
                PlaceId = "5f8c4ce3d90e94643c8a4030",
                Name = "Delhi",
                Picture = "",
                Description = "With old monuments and busy neighbourhoods subtly merging with a vibrant and contemporary cosmopolitan world, Delhi, the capital of India, is a fascinating tourist destination. Poised along the banks of River Yamuna, Delhi, which is almost 1,000 years old,",
                Attraction = "India Gate, Red Fort, Akshardham, Jama Masjid",
                Experiences = "Heritage, Spritual, Food And Cuisine",
                Distance = 1,
                DestinationId = "5f8c4c18d90e94643c8a402f"
            };
            _destination = new Destination()
            {
                DestinationId = "5f8c4c18d90e94643c8a402f",
                Name = "All Destinations",
                Url = "~/Tourist",
                OpenInNewWindow = false
            };
            _tourGuide = new TourGuide()
            {
                TourId = "5f8c4da5d90e94643c8a4031",
                Name = "Tour Operator Name",
                Phone = 9631438113,
                Email = "umakumarsingh@gmail.com",
                Address = "A-1, New Delhi",
                Experience = "7 Years",
                Remark = "Ok"
            };
            _aboutIndia = new AboutIndia()
            {
                Id = "5f8c4e80d90e94643c8a4032",
                About = "India is one of the oldest civilizations in the world with a kaleidoscopic variety and rich cultural heritage. It has achieved all-round socio-economic progress during the last 65 years of its Independence. India has become self-sufficient in agricultural production and is now one of the top industrialized countries in the world and one of the few nations to have gone into outer space to conquer nature for the benefit of the people. It covers an area of 32, 87,263 sq. km, extending from the snow-covered Himalayan heights to the tropical rain forests of the south. As the 7th largest country in the world, India stands apart from the rest of Asia, marked off as it is by mountains and the sea, which give the country a distinct geographical entity. Bounded by the Great Himalayas in the north, it stretches southwards and at the Tropic of Cancer, tapers off into the Indian Ocean between the Bay of Bengal on the east and the Arabian Sea on the west. As you travel, India offers a range of vast tourism choices, diverse in land and nature, people, tribes, cuisine, faiths, dance forms, music, arts, crafts, adventure, sport, spirituality, history; even these vary as you journey from one state to another. As a country, India has achieved all-round socio-economic progress in the last 70 years of independence. The change is clearly visible in the Tier I and Tier II cities. However, the fascinating aspect lies in the stark difference as you travel through the new and old parts of its cities. From world-class airports and hotels, luxurious shopping malls, restaurants, pubs and cafes to overcrowded streets and alleyways, in the same cities, filled with thousands of little shops offering every possible modern and ethnic product and native street food is a fascinating experience.",
                Visa = "All foreign nationals entering India are required to possess a valid international travel document in the form of a national passport with a valid visa obtained from an Indian Mission or Post abroad. Tourist Visa can only be granted to a foreigner who does not have a residence or occupation in India and whose sole objective of visiting India is recreation, sight seeing, casual visit to meet friends and relatives, etc.",
                Currency = "India Rupees",
                Language = "Hindi, English, Bengali, Marathi, Telugu, Tamil, Gujarati, Urdu, Kannada, Odia, Malayalam, Punjabi, Sanskrit",
                State = "Andhra Pradesh, Arunachal Pradesh, Assam, Bihar, Chhattisgarh, Goa, Gujarat, Haryana, Himachal Pradesh, Jharkhand, Karnataka, Kerala, Madhya Pradesh, Maharashtra, Manipur, Meghalaya, Mizoram, Nagaland, Odisha, Punjab, Rajasthan, Sikkim, Tamil Nadu, Telangana, Tripura, Uttar Pradesh, Uttarakhand, West Bengal.",
                UNION_TERRITORIES = "Andaman & Nicobar, Chandigarh, Dadra & Nagar Haveli, Daman & Diu, Delhi, Jammu & Kashmir, Ladakh, Lakshadweep, Puducherry",
                Climate = "SUMME, WINTER, RAINY, SPRING",
                How_Visit = "If you are from out of india, have a valid passport and visa., you can travel by air and train as well by road in india."
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using this test methd try to test and get all Contact Message from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllContactMessage()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllContactMessage());
            var result = await _adminTS.AllContactMessage();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllContactMessage=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get all Tour Operator from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllTourGuide()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllTourGuide());
            var result = await _adminTS.AllTourGuide();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllTourGuide=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get TourGuide by Id and try to get ReturnsAsync _tourGuide, if Passed Test True
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_TourGuideById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.TourGuideById(_tourGuide.TourId)).ReturnsAsync(_tourGuide);
            var result = await _adminTS.TourGuideById(_tourGuide.TourId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_TourGuideById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Tour Guide by TourId Id and TourGuide Collection
        /// if get updated then test Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateTourGuide()
        {
            //Arrange
            bool res = false;
            var _tourUpdate = new TourGuide()
            {
                TourId = "",
                Name = "Tour Operator Name",
                Phone = 9631438113,
                Email = "umakumarsingh@gmail.com",
                Address = "A-1, New Delhi",
                Experience = "7 Years",
                Remark = "Ok"
            };
            //Act
            adminService.Setup(repo => repo.UpdateTourGuide(_tourUpdate.TourId, _tourUpdate)).ReturnsAsync(_tourUpdate);
            var result = await _adminTS.UpdateTourGuide(_tourUpdate.TourId, _tourUpdate);
            if (result == _tourUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateTourGuide=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add new Place is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_AddNewPlace()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddNewPlace(_place)).ReturnsAsync(_place);
            var result = await _adminTS.AddNewPlace(_place);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_AddNewPlace=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Place by PlaceId and Place Collection
        /// if get updated then test Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdatePlace()
        {
            //Arrange
            bool res = false;
            var _placeUpdate = new Place()
            {
                PlaceId = "",
                Name = "Delhi",
                Picture = "",
                Description = "With old monuments and busy neighbourhoods subtly merging with a vibrant and contemporary cosmopolitan world, Delhi, the capital of India, is a fascinating tourist destination. Poised along the banks of River Yamuna, Delhi, which is almost 1,000 years old,",
                Attraction = "India Gate, Red Fort, Akshardham, Jama Masjid",
                Experiences = "Heritage, Spritual, Food And Cuisine",
                Distance = 1,
                DestinationId = ""
            };
            //Act
            adminService.Setup(repo => repo.UpdatePlace(_placeUpdate.PlaceId, _placeUpdate)).ReturnsAsync(_placeUpdate);
            var result = await _adminTS.UpdatePlace(_placeUpdate.PlaceId, _placeUpdate);
            if (result == _placeUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdatePlace=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add new Destination is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_AddNewDestination()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AddNewDestination(_destination)).ReturnsAsync(_destination);
            var result = await _adminTS.AddNewDestination(_destination);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_AddNewDestination=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get Destination by Id and try to get ReturnsAsync Destination Object, if Passed Test True
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_TourDestinationById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DestinationById(_destination.DestinationId)).ReturnsAsync(_destination);
            var result = await _adminTS.DestinationById(_destination.DestinationId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_TourDestinationById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Destination by DestinationId and Destination Collection
        /// if get updated then test Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateDestination()
        {
            //Arrange
            bool res = false;
            var _destinationUpdate = new Destination()
            {
                DestinationId = "",
                Name = "All Destinations",
                Url = "~/Tourist",
                OpenInNewWindow = false
            };
            //Act
            adminService.Setup(repo => repo.UpdateDestination(_destinationUpdate.DestinationId, _destinationUpdate)).ReturnsAsync(_destinationUpdate);
            var result = await _adminTS.UpdateDestination(_destinationUpdate.DestinationId, _destinationUpdate);
            if (result == _destinationUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateDestination=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add Abut India Text is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_AddAboutIndia()
        {
            //Arrange
            bool res = false;
            //Act
            adminService.Setup(repo => repo.AboutIndia(_aboutIndia)).ReturnsAsync(_aboutIndia);
            var result = await _adminTS.AboutIndia(_aboutIndia);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_AddAboutIndia=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Tour Guide by TourId Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteTourGuide()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteTourGuide(_tourGuide.TourId)).ReturnsAsync(true);
            var resultDelete = await _adminTS.DeleteTourGuide(_tourGuide.TourId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteTourGuide=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Place by PlaceId, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeletePlace()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeletePlace(_place.PlaceId)).ReturnsAsync(true);
            var resultDelete = await _adminTS.DeletePlace(_place.PlaceId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeletePlace=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete Destination by DestinationId, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteDestination()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteDestination(_destination.DestinationId)).ReturnsAsync(true);
            var resultDelete = await _adminTS.DeleteDestination(_destination.DestinationId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteDestination=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get all Place from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAllPlaces()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.GetAllPlaces());
            var result = await _tourGS.GetAllPlaces();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetAllPlaces=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get Place By Id from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetPlaceById()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.GetPlaceById(_place.PlaceId)).ReturnsAsync(_place);
            var result = await _tourGS.GetPlaceById(_place.PlaceId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetPlaceById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get Place By DestinationId from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetPlaceByDestinationId()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.GetPlaceByDestinationId(_place.DestinationId)).ReturnsAsync(_destination);
            var result = await _tourGS.GetPlaceByDestinationId(_place.DestinationId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetPlaceByDestinationId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get Place By Attraction from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_PlaceByAttraction()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.PlaceByAttraction(_place.Attraction));
            var result = await _tourGS.PlaceByAttraction(_place.Attraction);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_PlaceByAttraction=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Hire a Tour Guide is getting Hired, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_HireTourGuide()
        {
            //Arrange
            bool res = false;
            //Act
            tourService.Setup(repo => repo.HireTourGuide(_tourGuide));
            var result = await _tourGS.HireTourGuide(_tourGuide);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_HireTourGuide=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get all Information AbouIndia from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_KnowAboutIndia()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.KnowAboutIndia());
            var result = await _tourGS.KnowAboutIndia();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_KnowAboutIndia=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test methd try to test and get Place By DestinationId from Services and Repository method
        /// if get and result is not null, test passed.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_TourGuideInformation()
        {
            //Arrange
            var res = false;
            //Action
            tourService.Setup(repos => repos.TourGuideInformation(_tourGuide.TourId)).ReturnsAsync(_tourGuide);
            var result = await _tourGS.TourGuideInformation(_tourGuide.TourId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_TourGuideInformation=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add a message for Tour Information is getting Added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Add_Valid_UserContactUs()
        {
            //Arrange
            bool res = false;
            //Act
            tourService.Setup(repo => repo.UserContactUs(_contactUs)).ReturnsAsync(_contactUs);
            var result = await _tourGS.UserContactUs(_contactUs);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_Add_Valid_UserContactUs=" + res + "\n");
            return res;
        }
    }
}
