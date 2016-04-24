
using System;
using System.Globalization;
using System.Threading;

using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(HindiXamApp.iOS.LocaleService))]
namespace HindiXamApp.iOS
{
    public class LocaleService : ILocalize
    {
        public void SetLocale()
        {
            var ci = GetCurrentCultureInfo();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Console.WriteLine("SetLocale: " + ci.Name);
        }
        public CultureInfo GetCurrentCultureInfo()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;    // en_FR
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;      // en
            var netLocale = iosLocaleAuto.Replace("_", "-");
            const string defaultCulture = "en";

            CultureInfo ci = null;
            if (NSLocale.PreferredLanguages.Length > 0)
            {               
                try
                {
                    var pref = NSLocale.PreferredLanguages[0];
                    var netLanguage = pref.Replace("_", "-");
                    ci = CultureInfo.CreateSpecificCulture(netLanguage);
                }
                catch
                {
                    ci = new CultureInfo(defaultCulture);
                }
            }
            else
            {
                ci = new CultureInfo(defaultCulture); // default, shouldn't really happen :)
            }
            return ci;
        }
        public CultureInfo GetCurrentCultureInfo(string sLanguageCode)
        {
            return CultureInfo.CreateSpecificCulture(sLanguageCode);
        }
        public void ChangeLocale(string sLanguageCode) {
            var ci = CultureInfo.CreateSpecificCulture(sLanguageCode);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Console.WriteLine("ChangeToLanguage: " + ci.Name);
        }
    }
}
