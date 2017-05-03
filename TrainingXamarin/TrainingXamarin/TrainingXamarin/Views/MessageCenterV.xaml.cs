using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageCenterV : ContentPage
    {
        public MessageCenterV()
        {
            InitializeComponent();

            BindingContext = new MessageCenterVM();

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<MessageCenterV, string>(this, "Hi", (sender, arg) => {
                DisplayAlert("Message Received", "arg=" + arg, "OK");
            });

            listView.SetBinding(ListView.ItemsSourceProperty, "Greetings");

        }

        private void Button_Clicked_Hi(object sender, EventArgs e)
        {
            MessagingCenter.Send<MessageCenterV>(this, "Hi");
        }

        private void Button_Clicked_HiJohn(object sender, EventArgs e)
        {
            MessagingCenter.Send<MessageCenterV, string>(this, "Hi", "John");
        }

        private void Button_Clicked_Unsubscribe(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MessageCenterV, string>(this, "Hi");
            DisplayAlert("Unsubscribed",
                "This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.",
                "OK");
        }

        private void Button_Clicked_Navigator(object sender, EventArgs e)
        {
            MessagingCenter.Send<MessageCenterV>(this, "Navigator");
        }
    }
}
