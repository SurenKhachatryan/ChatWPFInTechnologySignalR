using BLL.Helpers;

namespace BLL.Core
{
    public class Services
    {
        public static HttpHelpers HttpHelpers { get { return _httpHelpers; } }



        private static HttpHelpers _httpHelpers;

        public Services(HttpHelpers httpHelpers)
        {
            _httpHelpers = httpHelpers;
        }
    }
}
