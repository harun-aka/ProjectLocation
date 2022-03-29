using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding Attributelar typeofla çalıştığı için kontrol etmeliyiz.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)  //Burada method interceptiondaki metodu override ederek içini doldururuz ve try-catchden önce çalışır. Ör: Add metodu.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //Reflection, çalışma anında birşeyleri çalışma anında yapılmasını sağlar buradaki gibi. Ör: ProductValidator.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];   //Base type ın generic elemanlarının 0. sını getirir. Ör: AbstractValidator<Product> => Product.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // ProductManager ın çalışmasını istediği metodun parametrelerinden validator ın tipine 
            foreach (var entity in entities)                                           // eşit olan parametreleri bul der. Ör: Add metodunun argümanları arasında validate edilmesi gerekenleri bul.
            {
                ValidationTool.Validate(validator, entity); //her bir parametreyi tek tek gez ValidationTool u kullanadarak validate et.
            }
        }
    }
}
