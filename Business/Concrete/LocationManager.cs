using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LocationManager : ILocationService
    {
        ILocationDal _locationDal;
        ITimeZonesService _timeZonesService;

        public LocationManager(ILocationDal locationDal, ITimeZonesService timeZonesService)
        {
            _locationDal = locationDal;
            _timeZonesService = timeZonesService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LocationValidator))]
        [TransactionScopeAspect()]
        public IResult Add (LocationEditDto locationDto)
        {

            IDataResult<TimeZones> timeZonesResult = _timeZonesService.GetById(locationDto.TimeZonesId);
            if(timeZonesResult.Data == null)
            {
                return new ErrorResult(Messages.TimeZoneInvalid);
            }


            IResult result = BusinessRules.Run(CheckMinOpenHours(locationDto.OpeningTime, locationDto.ClosingTime), 
                CheckMaxOpenHours(locationDto.OpeningTime, locationDto.ClosingTime));

            if(result != null)
            {
                return new ErrorResult(result.Message);
            }

            Location location = new Location
            {
                Name = locationDto.Name,
                Address = locationDto.Address,
                OpeningTime = locationDto.OpeningTime.TimeOfDay,
                ClosingTime = locationDto.ClosingTime.TimeOfDay,
                TimeZonesId = locationDto.TimeZonesId
            };

            _locationDal.Add(location);
            return new SuccessResult(Messages.LocationAdded);
        }

        [SecuredOperation("admin")]
        [TransactionScopeAspect()]
        public IResult Delete(int locationId)
        {
            IDataResult<Location> result = GetById(locationId);
            if(result.Data == null)
            {
                return new ErrorResult(Messages.LocationNotFound);
            }

            _locationDal.Delete(result.Data);
            return new SuccessResult(Messages.LocationDeleted);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<LocationListDto>> GetAll()
        {
            return new SuccessDataResult<List<LocationListDto>>(_locationDal.GetAllListDto(),Messages.LocationsListed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<Location> GetById(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(p => p.Id == locationId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LocationValidator))]
        [TransactionScopeAspect()]
        public IResult Update(LocationEditDto locationDto)
        {
            IDataResult<TimeZones> timeZonesResult = _timeZonesService.GetById(locationDto.TimeZonesId);
            if (timeZonesResult.Data == null)
            {
                return new ErrorResult(Messages.TimeZoneInvalid);
            }

            IResult result = BusinessRules.Run(CheckMinOpenHours(locationDto.OpeningTime, locationDto.ClosingTime),
                CheckMaxOpenHours(locationDto.OpeningTime, locationDto.ClosingTime));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            Location location = new Location
            {
                Id = locationDto.Id,
                Name = locationDto.Name,
                Address = locationDto.Address,
                OpeningTime = locationDto.OpeningTime.TimeOfDay,
                ClosingTime = locationDto.ClosingTime.TimeOfDay,
                TimeZonesId = locationDto.TimeZonesId
            };

            _locationDal.Update(location);
            return new SuccessResult(Messages.locationUpdated);
        }

        private static IResult CheckMaxOpenHours(DateTime openingtime, DateTime closingTime)
        {
            if (closingTime.TimeOfDay - openingtime.TimeOfDay > TimeSpan.FromHours(8))
            {
                return new ErrorResult("Lokasyon en fazla 8 saat açık kalabilir.");
            }
            return new SuccessResult();
        }

        private static IResult CheckMinOpenHours(DateTime openingtime, DateTime closingTime)
        {
            if (closingTime.TimeOfDay - openingtime.TimeOfDay < TimeSpan.FromHours(2))
            {
                return new ErrorResult("Lokasyon en az 2 saat açık kalmalıdır.");
            }
            return new SuccessResult();
        }

    }
}
