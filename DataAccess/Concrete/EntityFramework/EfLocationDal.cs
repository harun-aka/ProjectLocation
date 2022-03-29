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
    public class EfLocationDal : EfEntityRepositoryBase<Location, ProjectLocationContext>, ILocationDal
    {
        public List<LocationListDto> GetAllListDto()
        {
            using (ProjectLocationContext context = new ProjectLocationContext())
            {
                var result = from l in context.Locations
                             select new LocationListDto
                             {
                                 Id = l.Id,
                                 Address = l.Address,
                                 Name = l.Name
                             };
                return result.ToList();
            }
        }
    }
}
