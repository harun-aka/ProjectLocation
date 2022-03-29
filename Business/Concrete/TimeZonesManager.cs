using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TimeZonesManager : ITimeZonesService
    {
        ITimeZonesDal _timeZonesDal;

        public TimeZonesManager(ITimeZonesDal timeZonesDal)
        {
            _timeZonesDal = timeZonesDal;
        }

        public IDataResult<List<TimeZones>> GetAll()
        {
            return new SuccessDataResult<List<TimeZones>>(_timeZonesDal.GetAll());
        }

    }
}
