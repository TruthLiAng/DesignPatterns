using Autofac;
using L0_Core.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L2_Aotufac
{
    class Program
    {
        static IContainer container = null; 
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            Type baseType = typeof(IDependency);

            // 获取所有相关类库的程序集
            //DLL所在的绝对路径 
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "L0-Core.dll");

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证对象生命周期基于请求

            container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            test();
        }
        
        private static void test()
        {
            ITimePut put = container.Resolve<ITimePut>();

            put.TimeOutPut();
        }
    }
}
