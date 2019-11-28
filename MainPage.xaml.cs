using PTM_Frontend.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace PTM_Frontend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            home.IsSelected = true;
            back_but.Visibility = Visibility.Collapsed;
            myframe.Navigate(typeof(Home));
        }
        private void Hamburger_but_Click(object sender, RoutedEventArgs e)
        {
            mysplitview.IsPaneOpen = !mysplitview.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (home.IsSelected)
            {
                back_but.Visibility = Visibility.Collapsed;
                myframe.Navigate(typeof(Home));
                title_tb.Text = "Home";
                delete_db.Visibility = Visibility.Collapsed;

            }
            else if (soil_humidity.IsSelected)
            {
                back_but.Visibility = Visibility.Visible;
                myframe.Navigate(typeof(TrafficDensity));
                title_tb.Text = "Soil Humidity";
                delete_db.Visibility = Visibility.Collapsed;

            }
            else if (smoke_content.IsSelected)
            {
                back_but.Visibility = Visibility.Visible;
                myframe.Navigate(typeof(PedCrossing));
                title_tb.Text = "Smoke Content";
                delete_db.Visibility = Visibility.Collapsed;
            }
        }
    }
}
