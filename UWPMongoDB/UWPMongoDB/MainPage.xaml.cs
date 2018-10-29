using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPMongoDB.Helper;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPMongoDB
{
    
    public sealed partial class MainPage : Page
    {
        List<User> lstSources = new List<User>();
        User saveData;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void updateView(List<User> users)
        {
            lstView.ItemsSource = null;
            lstView.ItemsSource = users;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            lstSources = await Helper.Helper.getAllUser();
            lstView.ItemsSource = lstSources;
        }

        private void lstView_ItemClick(object sender, ItemClickEventArgs e)
        {
            saveData = e.ClickedItem as User;
            edtUserName.Text = saveData.user;
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            await Helper.Helper.insertNewUser(edtUserName.Text);
            updateView(await Helper.Helper.getAllUser());
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            await Helper.Helper.updateUser(saveData,edtUserName.Text);
            updateView(await Helper.Helper.getAllUser());
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            await Helper.Helper.deleteUser(saveData);
            updateView(await Helper.Helper.getAllUser());
        }
    }
}
