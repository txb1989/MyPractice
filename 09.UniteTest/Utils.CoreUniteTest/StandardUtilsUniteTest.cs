using Jst.UtilStandard;
using Jst.UtilStandard.EnumExt;
using Jst.UtilStandard.Extension;
using Jst.UtilStandard.UtilsHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Utils.CoreUniteTest
{
    [TestClass]
    public class StandardUtilsUniteTest
    {
        #region time test
        [TestMethod]
        public void TestTimeStandard()
        {

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.UtcNow;
            Console.Write($"{time1.ToString()}----{time2.ToString()}  ");
        }

        [TestMethod]
        public void TestTimeStampToTimeStandard()
        {
            long timestamp1 = 1501663571L;//时间：2017/8/2 16:46:11
            DateTime time1 = Convert.ToDateTime("2017/8/2 16:46:11");
            DateTime time = DateTimeHelper.ConvertStampToTime(timestamp1);
            Assert.AreEqual(time1, time);

            long timestamp2 = 1186574400L;//时间：2007/8/8 20:00:00
            DateTime time2 = Convert.ToDateTime("2007/8/8 20:00:00");
            time = DateTimeHelper.ConvertStampToTime(timestamp2);
            Assert.AreEqual(time2, time);
        }

        [TestMethod]
        public void TestTimeToTimeStampStandard()
        {
            DateTime time2 = Convert.ToDateTime("2007/8/8 20:00:00");
            long timestamp2 = 1186574400L;
            long timestamp = DateTimeHelper.ConvertTimeToStamp(time2);
            Assert.AreEqual(timestamp2, timestamp);

            DateTime time1 = Convert.ToDateTime("2017/8/2 16:46:11");
            long timestamp1 = 1501663571L;
            timestamp = DateTimeHelper.ConvertTimeToStamp(time1);
            Assert.AreEqual(timestamp1, timestamp);
        }
        #endregion

        #region 加密解密测试

        [TestMethod]
        public void TestMd5Standard()
        {

            string secret1 = "e10adc3949ba59abbe56e057f20f883e";
            string pwd1 = "123456";
            string secret = EncryptHelper.Md532(pwd1);
            Assert.AreEqual(secret1, secret, true);
            string secret2 = "d17515860d4f63c6f3c48acc181e72c7";
            string pwd2 = "tang123456@";
            secret = EncryptHelper.Md532(pwd2);
            Assert.AreEqual(secret2, secret, true);
        }

        [TestMethod]
        public void TestAesStandard()
        {
            string ikey = "123698745159753852456";
            string ivalue = "95135746585274123698";
            string secret = "123456".AesStr(ikey, ivalue);
            string orgin = secret.UnAesStr(ikey, ivalue);
            Assert.AreEqual(orgin, "123456");
        }

        [TestMethod]
        public void TestDesStandard()
        {
            string ikey = "123698745159753852456";
            string ivalue = "95135746585274123698";
            //Assert.AreEqual("123456".Des(ikey, ivalue).UnDes(ikey,ivalue), "123456");
        }

        #endregion

        #region Enum Test

        [TestMethod]
        public void TestGetDescription()
        {
            EnumGender gender = EnumGender.Male;
            string description = gender.GetDescription();
            Assert.AreEqual("男", description);
            gender = EnumGender.Unknown;
            Assert.AreEqual("未知", gender.GetDescription());
        }

        [TestMethod]
        public void TestGetAllEnums()
        {
            List<EnumItem> enumList = EnumHelper.GetEnumList<EnumGender>();

            Assert.AreEqual(enumList.Count, 3);
            foreach (var item in enumList)
            {
                Console.Write(item.ToJson());
            }

        }

        #endregion

        #region FileHelperTest

        [TestMethod]
        public void TestLogStandard()
        {

        }



        #endregion

        [TestMethod]
        public void TestRandomStandard()
        {
            string str1 = RandomHelper.GetRandomString(5);
            string str2 = RandomHelper.GetRandomString(5);
            Assert.AreNotEqual(str1, str2);

        }
    }

    public enum EnumGender
    {
        [System.ComponentModel.Description("未知")]
        Unknown = 0,
        [System.ComponentModel.Description("男")]
        Male = 1,
        [System.ComponentModel.Description("女")]
        Female = 2
    }
}
