using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Contact> contactsCollect = new ObservableCollection<Contact>();
        public MainPage()
        {
            InitializeComponent();
            GetContactsHelper();
        
        }

        private async void GetContactsHelper()
        {
            try
            {
                // cancellationToken parameter is optional
                var cancellationToken = default(CancellationToken);
                var contacts = await Contacts.GetAllAsync(cancellationToken);

                if (contacts == null)
                    return;

                foreach (var contact in contacts)
                    contactsCollect.Add(contact);
            }
            catch (Exception ex)
            {
                // Handle exception here.
            }

            ContactList.ItemsSource = null;
            ContactList.ItemsSource = contactsCollect;
        }
    }
}
