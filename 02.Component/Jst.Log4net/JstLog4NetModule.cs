using Jst.Core.Ioc;
using Jst.Core.Log;
using Jst.Core.Module;

namespace Jst.Log4Net
{
    public class JstLog4NetModule : CoreComponentModule
    {
        public override void PreInit(IIocManager instance)
        {
            instance.RegisterType<JstCoreLog4net, IJstCoreLogs>(interceptor: false);
            base.PreInit(instance);
        }
    }
}
