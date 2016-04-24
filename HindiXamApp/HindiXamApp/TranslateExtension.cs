using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HindiXamApp
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "HindiXamApp.Resx.AppResources";

        public TranslateExtension()
        {
            if (string.IsNullOrEmpty(App.CultureCode))
            {
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
            else ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo(App.CultureCode);
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager temp = new ResourceManager(ResourceId , typeof(TranslateExtension).GetTypeInfo().Assembly);
            var translation = temp.GetString(Text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name), "Text");
#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
