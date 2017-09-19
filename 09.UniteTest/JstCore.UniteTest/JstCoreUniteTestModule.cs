using Ioc.Test.Services;
using Jst.Core.Ioc;
using Jst.Core.Module;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ioc.Test
{
    public class JstCoreUniteTestModule : JstAppModuleBase
    {
        public  override void PreInit(IIocManager instance)
        {
            instance.RegisterGeneric(typeof(MyServiceGeneric<>), typeof(IServiceGeneric<>));
            instance.RegisterType(typeof(MyServiceGeneric2), typeof(IServiceGeneric2<int>));
            instance.RegisterGeneric(typeof(MyObjectProvider<>), typeof(IObjectProvider<>));
            instance.RegisterGeneric(typeof(RepositoryA<,>), typeof(IRepository<,>), "RepositoryA");
            instance.RegisterGeneric(typeof(RepositoryB<,>),typeof(IRepository<,>), "RepositoryB");
            instance.RegisterTypeAsObject(false, Assembly.GetExecutingAssembly().GetTypes().Where(c=>typeof(MyDbObject).IsAssignableFrom(c)).ToArray());
            instance.RegisterAssemblies(Assembly.GetExecutingAssembly());
            base.PreInit(instance);
        }
    }
}
