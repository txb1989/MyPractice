using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Utils.Extension;
using Jst.Utils.UtilsHelper;
using System.Collections.Generic;
using Jst.Utils.EnumExt;
using Newtonsoft.Json;
using Jst.Utils;

namespace Utils.CoreUniteTest
{
    [TestClass]
    public class EnumExtTest
    {
        [TestMethod]
        public void TestGetDescription()
        {
            EnumGender gender = EnumGender.Male;
            string description = gender.GetDescription();
            Assert.AreEqual("��",description);
            gender = EnumGender.Unknown;
            Assert.AreEqual("δ֪", gender.GetDescription());
        }

        [TestMethod]
        public void TestGetAllEnums()
        {
            List<EnumItem> enumList = EnumHelper.GetEnumList<EnumGender>();

            Assert.AreEqual(enumList.Count, 4);
            foreach(var item in enumList)
            {
                Console.Write(item.ToJson());
            }

        }


    }

    public enum EnumGender
    {
        [System.ComponentModel.Description("��")]
        Male=0,
        [System.ComponentModel.Description("Ů")]
        Female =1,
        [System.ComponentModel.Description("����")]
        Secrete = 2,
        [System.ComponentModel.Description("δ֪")]
        Unknown =-999999,
    }
}
