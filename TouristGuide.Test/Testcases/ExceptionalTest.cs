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
    public class ExceptionalTest
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
        public ExceptionalTest()
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
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// This Method is used for test Add Contact Us Message is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_ContactUsMessage()
        {
            //Arrange
            bool res = false;
            _contactUs = null;
            //Act
            tourService.Setup(repo => repo.UserContactUs(_contactUs)).ReturnsAsync(_contactUs = null);
            var result = await _tourGS.UserContactUs(_contactUs);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_ContactUsMessage=" + res + "\n");
            return res;
        }
        /// <summary>
        /// This Method is used for test Add New Place is valid or not, contact us is invalid return null.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddNewPlace()
        {
            //Arrange
            bool res = false;
            _place = null;
            //Act
            adminService.Setup(repo => repo.AddNewPlace(_place)).ReturnsAsync(_place = null);
            var result = await _adminTS.AddNewPlace(_place);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddNewPlace=" + res + "\n");
            return res;
        }
        /// <summary>
        /// This Method is used for test Add New Destination is valid or not, if Destination is invalid return null.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddNewDestination()
        {
            //Arrange
            bool res = false;
            _place = null;
            //Act
            adminService.Setup(repo => repo.AddNewDestination(_destination)).ReturnsAsync(_destination = null);
            var result = await _adminTS.AddNewDestination(_destination);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddNewDestination=" + res + "\n");
            return res;
        }
        /// <summary>
        /// This Method is used for test Add About India is valid or not, if Destination is invalid return null.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddAboutIndia()
        {
            //Arrange
            bool res = false;
            _aboutIndia = null;
            //Act
            adminService.Setup(repo => repo.AboutIndia(_aboutIndia)).ReturnsAsync(_aboutIndia = null);
            var result = await _adminTS.AboutIndia(_aboutIndia);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddAboutIndia=" + res + "\n");
            return res;
        }
    }
}
