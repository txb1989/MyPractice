using Jst.Core.Ioc;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Linq;
using System;

namespace Jst.Core.Module
{
    public class AssemblyLoader
    {

        public static void LoadAssemblies(Assembly startAssembly, List<JstModuleInfo> moduleList)
        {
            if (moduleList == null) throw new ArgumentNullException("ModuleList is Null");

            #region 查找引用的程序集
            List<AssemblyName> refference = startAssembly.GetReferencedAssemblies().ToList();
            if (refference != null && refference.Count > 0)
            {
                foreach (AssemblyName assemblyName in refference)
                {
                    Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName);
                    var typeInfo = assembly.DefinedTypes.FirstOrDefault(tp =>
                    typeof(IJstAppModule).IsAssignableFrom(tp.AsType())
                    && !tp.IsInterface && !tp.IsAbstract
                    );

                    if (typeInfo != null)
                    {
                        LoadAssemblies(assembly, moduleList);
                    }
                }
            }
            #endregion

            #region 查找当前程序集
            TypeInfo typeinfo = startAssembly.DefinedTypes.FirstOrDefault(tp =>
                      typeof(IJstAppModule).IsAssignableFrom(tp.AsType())
                      && !tp.IsInterface && !tp.IsAbstract);
            if (typeinfo != null)
            {
                Type type = typeinfo.AsType();
                IJstAppModule _instance = startAssembly.CreateInstance(type.FullName, false) as IJstAppModule;
                moduleList.Add(new JstModuleInfo()
                {
                    AssemblyInfo = startAssembly,
                    Instance = _instance,
                    ModuleName = type.FullName,
                    SortNo = _instance.SortNo
                }); 
                #endregion
            }

            
        }
    }
}
