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
        IDataResult<List<Location>> GetAll();
        IDataResult<Location> GetById(int productId);
        IResult Add(Location product);
        IResult Update(Location product);
        IResult Delete(Location product);
    }
}
