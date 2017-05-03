using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingXamarin.Views;
using Xamarin.Forms;

namespace TrainingXamarin.ViewModels
{
    public class MessageCenterVM
    {
        public ObservableCollection<string> Greetings { get; set; }

        public MessageCenterVM()
        {
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<MessageCenterV>(this, "Hi", (sender) => {
                Greetings.Add("Hi");
            });

            MessagingCenter.Subscribe<MessageCenterV>(this, "Navigator", async (sender) => {
                await App.Current.MainPage.Navigation.PushAsync(new TriggerPage());
            });

            MessagingCenter.Subscribe<MessageCenterV, string>(this, "Hi", (sender, arg) => {
                Greetings.Add("Hi " + arg);
            });
        }
    }
}
