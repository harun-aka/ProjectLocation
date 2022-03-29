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
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(LocationValidator))]  
        public IResult Add (Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Delete(Location location)
        {
            _locationDal.Add(location);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("admin, user")]
        public IDataResult<List<Location>> GetAll()
        {

            return new SuccessDataResult<List<Location>>(_locationDal.GetAll(),Messages.LocationsListed);
        }

        [SecuredOperation("admin, user")]
        public IDataResult<Location> GetById(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.Get(p => p.Id == locationId));
        }

        [SecuredOperation("admin")]
        public IResult Update(Location location)
        {
            _locationDal.Update(location);
            return new SuccessResult(Messages.ProductUpdated);
        }
        
    }
}
