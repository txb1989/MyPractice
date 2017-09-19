﻿using Jst.Core.Enums;
using Jst.Core.Ioc;

namespace Jst.Core.Module
{
    public abstract class JstAppModuleBase : IJstAppModule
    {
        public virtual int SortNo { get { return 0; }  }

        public virtual void PreInit(IIocManager instance)
        {
            
            //instance.RegisterAssemblies(Assembly.GetCallingAssembly());
        }
        public virtual void Init(JstModuleInfo module)
        {
            //IocManager.Instance.RegisterAssembly(module.AssemblyInfo, c => true);
        }

        public virtual void PostInit()
        {
        }
        
    }
    

    public class CoreComponentModule : JstAppModuleBase, ICoreComponentModule
    {
        public override int SortNo { get { return (int)EnumModuleComponent.CoreComponent; } }
    }

    public class BusyComponentModule : JstAppModuleBase, IBusyComponentModule
    {
        public override int SortNo { get { return (int)EnumModuleComponent.BusyComponent; } }
    }


}
