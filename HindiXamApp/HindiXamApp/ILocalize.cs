using System.Globalization;

namespace HindiXamApp
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        CultureInfo GetCurrentCultureInfo(string sLanguageCode);
        void SetLocale();
        void ChangeLocale(string sLanguageCode);
    }
}
