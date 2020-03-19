using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace MultiLanguageApplication.Models
{
    public class SiteLanguage
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            new Languages{LangFullName = "English", LangCultureName = "en"},
            new Languages{LangFullName = "Македонски", LangCultureName = "mk"},
            new Languages{LangFullName = "Shqip", LangCultureName = "shq"}
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string getDefaultLanguage()
        {
            return AvailableLanguages[0].LangCultureName;
        }

        public void setLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = getDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch(Exception ex)
            {

            }
        }
    }
    public class Languages
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
    }
}