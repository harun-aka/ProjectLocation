using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //NuGet 
        public void Add(TEntity entity)
        {
            //IDisposable pattern implemantation of c#
            using (TContext context = new TContext())//Böyle kullanmak daha performanslı olur.
                                                                     //Using ile yapmak zorunda değiliz yani.İşi bitince Garbage collector siler.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)  //Tek ürün getirirken filtre olmak zorunda bu yüzden filter = null yaparak başlangıç değeri vermedik.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //Çok ürün getirirken filtre olmak zorunda değil bu yüzden filter = null yaparak başlangıç değeri verdik.
        {
            using (TContext context = new TContext())
            {
                //Products a yerleş liste olarak getir.     //filtre varsa filtreye göre getir.
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
