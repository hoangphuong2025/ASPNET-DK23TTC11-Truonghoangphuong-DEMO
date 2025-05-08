namespace web_portal.App_Data
{
    using System;

    public class CSContextAdmin
    {
        private static string urlCurrent = "";

        public static string UrlCurrent
        {
            get
            {
                return urlCurrent;
            }
            set
            {
                urlCurrent = value;
            }
        }
    }
}

