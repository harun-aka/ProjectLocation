using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITimeZonesService
    {
        IDataResult<List<TimeZones>> GetAll();
        IDataResult<TimeZones> GetById(int timeZonesId);

    }
}
