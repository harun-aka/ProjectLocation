using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]  //AllowMultiple izni verilmesinin nedeni aynı işlemi farklı iki şekilde yapabilmek için.
                                                                                                                //Mesela hem dbye hem de dosyaya loglama işlemi yapabilmek için.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor   //AOP yapısını kullanmamızı sağlayacak yapı Autofac ile kuruldu.
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
