using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module  //Proje seviyesi injectionlar . Tüm projeler için yapılacak injectionları core da yaparız.
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocationManager>().As<ILocationService>().SingleInstance();  //Startup dosyası içinde yaptığımız işlemi artık burada yapıyoruz.
            builder.RegisterType<EfLocationDal>().As<IProductDal>().SingleInstance();        //Bunlar sadece operasyon olduğu için tek bir instance yeter.

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();               //Burada artık her uygulama için validation varsa önce onları konrol eder.
                                                                                            //Varsa eğer ne zaman yapılacaksa yapar.
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()               //Her interface için implemented interface için önce  bunun çalıştırır.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
