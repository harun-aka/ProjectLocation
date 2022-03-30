using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Test
{
    [TestClass]
    public class LocationManagerTests
    {
        Mock<ILocationDal> _mockLocationDal;
        Mock<ITimeZonesService> _mockTimeZonesService;
        TimeZones _dbTimeZones;
        List<LocationListDto> _dbLocationList;
        [TestInitialize]
        public void Start()
        {
            _mockLocationDal = new Mock<ILocationDal>();
            _dbLocationList = new List<LocationListDto>
            {
                new LocationListDto { Id = 1, Name = "Ev1", Address = "Antalya1"},
                new LocationListDto { Id = 2, Name = "Ev2", Address = "Antalya2"},
                new LocationListDto { Id = 3, Name = "Ev3", Address = "Antalya3"},
                new LocationListDto { Id = 4, Name = "Ev4", Address = "Antalya4"},
            };
            _mockLocationDal.Setup(m => m.GetAllListDto()).Returns(_dbLocationList);
            _mockLocationDal.Setup(m => m.Add(It.IsAny<Location>()));

            _mockTimeZonesService = new Mock<ITimeZonesService>();
            _dbTimeZones = new TimeZones { Id = 1, Name = "Ýst", TimeZoneInfoId = "Tr-Ist" };

        }

        [TestMethod]
        public void ListAllLocationsControlsCount()
        {
            //Arrange
            ILocationService _locationService = new LocationManager(_mockLocationDal.Object, _mockTimeZonesService.Object);
            //Act
            List<LocationListDto> locationLists = _locationService.GetAll().Data;
            //Assert
            Assert.AreEqual(4, locationLists.Count);
        }

        [TestMethod]
        public void CreateLocation_WithItemToCreate_ReturnsResult_Correct()
        {

            //Arrange
            _mockTimeZonesService.Setup(m => m.GetById(It.IsAny<int>())).Returns((new SuccessDataResult<TimeZones>(_dbTimeZones)));
            ILocationService _locationService = new LocationManager(_mockLocationDal.Object, _mockTimeZonesService.Object);
            //Act
            IResult result = _locationService.Add(new LocationEditDto
            {
                Id = 0,
                Name = "Ev5",
                Address = "Antalya5",
                TimeZonesId = 1,
                OpeningTime = new DateTime(1900, 1, 1, 10, 0, 0),
                ClosingTime = new DateTime(1900, 1, 1, 18, 0, 0)
            });
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void CreateLocation_WithItemToCreate_ReturnsResult_TimeZoneNull()
        {

            //Arrange
            _mockTimeZonesService.Setup(m => m.GetById(It.IsAny<int>())).Returns((IDataResult<TimeZones>) null);
            ILocationService _locationService = new LocationManager(_mockLocationDal.Object, _mockTimeZonesService.Object);
            //Act
            IResult result = _locationService.Add(new LocationEditDto
            {
                Id = 0,
                Name = "Ev5",
                Address = "Antalya5",
                TimeZonesId = 0,
                OpeningTime = new DateTime(1900, 1, 1, 10, 0, 0),
                ClosingTime = new DateTime(1900, 1, 1, 18, 0, 0)
            });
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Success);
        }

        [TestMethod]
        public void CreateLocation_WithItemToCreate_ReturnsResult_MinOpentimeFailure()
        {
            //Arrange
            _mockTimeZonesService.Setup(m => m.GetById(It.IsAny<int>())).Returns((new SuccessDataResult<TimeZones>(_dbTimeZones)));
            ILocationService _locationService = new LocationManager(_mockLocationDal.Object, _mockTimeZonesService.Object);
            //Act
            IResult result = _locationService.Add(new LocationEditDto { 
                Id = 1, 
                Name = "Ev5", 
                Address = "Antalya5", 
                TimeZonesId = 1, 
                OpeningTime = new DateTime(1900, 1, 1, 17, 0, 0), 
                ClosingTime = new DateTime(1900, 1, 1, 18, 0, 0)});
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Success);
        }
        [TestMethod]
        public void CreateLocation_WithItemToCreate_ReturnsResult_MaxOpentimeFailure()
        {
            //Arrange
            _mockTimeZonesService.Setup(m => m.GetById(It.IsAny<int>())).Returns((new SuccessDataResult<TimeZones>(_dbTimeZones)));
            ILocationService _locationService = new LocationManager(_mockLocationDal.Object, _mockTimeZonesService.Object);
            //Act
            IResult result = _locationService.Add(new LocationEditDto
            {
                Id = 1,
                Name = "Ev5",
                Address = "Antalya5",
                TimeZonesId = 1,
                OpeningTime = new DateTime(1900, 1, 1, 8, 0, 0),
                ClosingTime = new DateTime(1900, 1, 1, 18, 0, 0)
            });
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Success);
        }

    }
}