// -----------------------------------------------------------------------
// <copyright file="FuncModule.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Application.InversionOfControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Modules;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FuncModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(typeof(Func<>))
                .ToMethod(CreateFunc)
                .When(VerifyFactoryFunction)
                .InSingletonScope();
        }

        /// <summary>
        /// This method will verify if the requested type can be resolved into
        /// a autofactory.
        /// </summary>
        /// <param name="request">Ninject request</param>
        /// <returns>true if a auto-factory can be created, false otherwise.</returns>
        private static bool VerifyFactoryFunction(IRequest request)
        {
            // Is a Func<TReturn> with a single generic argument requested?
            // So no Func<T1,TReturn> or Func<T1,T2,TReturn> etc...
            var genericArguments = request.Service.GetGenericArguments();
            if (genericArguments.Count() != 1)
            {
                return false;
            }

            // Check if the service for wich the autofactory is requested, is 
            // registered in the kernel
            var instanceType = genericArguments.Single();
            return request.ParentContext.Kernel.CanResolve(new Request(instanceType, null, new IParameter[0], null, false, true)) ||
                   TypeIsSelfBindable(instanceType);
        }

        /// <summary>
        /// This method will create a Func&lt;T&gt; for the requested service.
        /// </summary>
        /// <param name="context">Ninject context</param>
        /// <returns>A Func&lt;T&gt; where T is the type of context.GenericArguments.Single()</returns>
        private static object CreateFunc(IContext context)
        {
            var functionFactoryType = typeof(FunctionFactory<>).MakeGenericType(context.GenericArguments);

            // Inject the kernel.
            var ctor = functionFactoryType.GetConstructors().Single();
            var functionFactory = ctor.Invoke(new object[] { context.Kernel });

            return functionFactoryType.GetMethod("Create").Invoke(functionFactory, new object[0]);
        }

        private static bool TypeIsSelfBindable(Type service)
        {
            return !service.IsInterface
                   && !service.IsAbstract
                   && !service.IsValueType
                   && service != typeof(string)
                   && !service.ContainsGenericParameters;
        }

        /// <summary>
        /// Inner helper class for creating generic Func&lt;T&gt; where
        /// the T is only known at runtime.
        /// </summary>
        /// <typeparam name="T">Type for wich Func&lt;T&gt; should be created</typeparam>
        public class FunctionFactory<T>
        {
            private readonly IKernel kernel;

            public FunctionFactory(IKernel kernel)
            {
                this.kernel = kernel;
            }

            public Func<T> Create()
            {
                return () => this.kernel.Get<T>();
            }
        }
    }
}
