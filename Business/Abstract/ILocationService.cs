using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationService  
    {
        IDataResult<List<LocationListDto>> GetAll();
        IDataResult<Location> GetById(int locationId);
        IResult Add(LocationEditDto location);
        IResult Update(LocationEditDto location);
        IResult Delete(Location location);
    }
}
