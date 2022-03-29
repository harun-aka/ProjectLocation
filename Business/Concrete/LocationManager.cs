using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LocationManager : ILocationService
    {
        ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }
        
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(LocationValidator))]
        [TransactionScopeAspect()]
        public IResult Add (LocationEditDto locationDto)
        {
            if (locationDto.ClosingTime.TimeOfDay - locationDto.OpeningTime.TimeOfDay > TimeSpan.FromHours(8))
            {
                return new ErrorResult("Lokasyon en fazla 8 saat açık kalabilir.");
            }

            Location location = new Location
            {
                Name = locationDto.Name,
                Address = locationDto.Address,
                OpeningTime = locationDto.OpeningTime.TimeOfDay,
                ClosingTime = locationDto.ClosingTime.TimeOfDay,
                TimeZoneId = locationDto.TimeZoneId
            };

            _locationDal.Add(location);
            return new SuccessResult(Messages.LocationAdded);
        }

        //[SecuredOperation("admin")]
        [TransactionScopeAspect()]
        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult(Messages.LocationDeleted);
        }

        //[SecuredOperation("admin, user")]
        public IDataResult<List<LocationListDto>> GetAll()
        {
            return new SuccessDataResult<List<LocationListDto>>(_locationDal.GetAllListDto(),Messages.LocationsListed);
        }

        //[SecuredOperation("admin, user")]
        public IDataResult<Location> GetById(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(p => p.Id == locationId));
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(LocationValidator))]
        [TransactionScopeAspect()]
        public IResult Update(LocationEditDto locationDto)
        {
            Location location = new Location
            {
                Id = locationDto.Id,
                Name = locationDto.Name,
                Address = locationDto.Address,
                OpeningTime = locationDto.OpeningTime.TimeOfDay,
                ClosingTime = locationDto.ClosingTime.TimeOfDay,
                TimeZoneId = locationDto.TimeZoneId
            };

            _locationDal.Update(location);
            return new SuccessResult(Messages.locationUpdated);
        }
        
    }
}
