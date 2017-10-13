using Ioc.Test.Services;
using Jst.Core.Ioc;
using Jst.Core.Log;
using Jst.UtilStandard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ioc.Test
{
    [TestClass]
    public class Log4NetUniteTest
    {
        public Log4NetUniteTest()
        {
            IocManager.Instance.StartApplication(typeof(JstCoreUniteTestModule).Assembly);
        }
        [TestMethod]
        public void TestLog()
        {
            IJstCoreLogs _logger = IocManager.Instance.Resolve<IJstCoreLogs>();
            _logger.Info("Hello world");
        }
    }
}
