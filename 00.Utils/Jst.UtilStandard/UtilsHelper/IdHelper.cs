using System;
using System.Collections.Generic;
using System.Text;

namespace Jst.UtilStandard.UtilsHelper
{
    public class IdHelper
    {
        public static long GetId()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            long id =  BitConverter.ToInt64(bytes, 0);
            return id;
        }

    }
}
