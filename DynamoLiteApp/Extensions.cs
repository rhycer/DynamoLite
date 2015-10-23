using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoLiteApp
{
    public static class Extensions
    {
        public static int? IntFromString(this string str)
        {
            try
            {
                int result = System.Convert.ToInt32(str);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static class Helpers
    {

        /// <summary>
        /// Returns a portion of GUID that should be unique-ish enough
        /// </summary>
        /// <returns></returns>
        public static string s4()
        {
            var newGuid = Guid.NewGuid();
            var arr = newGuid.ToString().Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var segment = arr[1];
            return segment.ToUpper();
        }
    }

}
