using System;
using Xamarin.Forms;

namespace HindiXamApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void OnPickerChanged(object sender, EventArgs args)
        {
            var vSelectedValue = pkrLanguage.Items[pkrLanguage.SelectedIndex];

            if (vSelectedValue.Trim() == "ಕನ್ನಡ")
            {
                DependencyService.Get<ILocalize>().ChangeLocale("kn");
                App.CultureCode = "kn";
            }
            else if(vSelectedValue.Trim() == "हिन्दी")
            {
                DependencyService.Get<ILocalize>().ChangeLocale("hi");
                App.CultureCode = "hi";
            }
            else
            {
              DependencyService.Get<ILocalize>().SetLocale();
              App.CultureCode = string.Empty;
            }
            var vUpdatedPage = new HomePage();
            Navigation.InsertPageBefore(vUpdatedPage, this);
            Navigation.PopAsync();
        }
    }
}
