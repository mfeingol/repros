using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(MainPage));
        public static readonly BindableProperty CheckoutDateProperty = BindableProperty.Create(nameof(CheckoutDate), typeof(DateTime), typeof(MainPage));
        public static readonly BindableProperty MinCheckoutDateProperty = BindableProperty.Create(nameof(MinCheckoutDate), typeof(DateTime), typeof(MainPage));

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            Device.BeginInvokeOnMainThread(() =>
            {
                DateTime minDate = new DateTime(2019, 7, 4);
                DateTime checkoutDate = new DateTime(2019, 7, 10);

                this.MinCheckoutDate = minDate;
                this.CheckoutDate = checkoutDate;

                this.TitleText = $"This should be set to {checkoutDate.ToShortDateString()}";
            });
        }

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public DateTime CheckoutDate
        {
            get { return (DateTime)GetValue(CheckoutDateProperty); }
            set { SetValue(CheckoutDateProperty, value); }
        }

        public DateTime MinCheckoutDate
        {
            get { return (DateTime)GetValue(MinCheckoutDateProperty); }
            set { SetValue(MinCheckoutDateProperty, value); }
        }
    }
}
