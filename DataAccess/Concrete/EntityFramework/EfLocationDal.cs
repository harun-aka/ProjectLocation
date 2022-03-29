using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLocationDal : EfEntityRepositoryBase<Location, NorthwindContext>, ILocationDal  //EfEntityRepositoryBase IProductDalın işlemlerini yaptığı için hata vermez.
    {
    }
}
