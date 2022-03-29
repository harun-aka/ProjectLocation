using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTimeZonesDal : EfEntityRepositoryBase<TimeZones, ProjectLocationContext>, ITimeZonesDal
    {        
    }
}
