using System.Reflection;

namespace Jst.Core.Module
{
    public class JstModuleInfo
    {
        /// <summary>
        /// 程序集
        /// </summary>
        public Assembly AssemblyInfo { get; set; }

        /// <summary>
        /// 实例
        /// </summary>
        public IJstAppModule Instance { get; set; }
        
        /// <summary>
        /// 模块名称，采用JstAppModule的类名
        /// </summary>
        public string ModuleName { get; set; }

        public int SortNo { get; set; }
    }
}
