using MQTTnet;
using MQTTnet.Client.Receiving;
using Newtonsoft.Json;
using PTM_Frontend.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PTM_Frontend.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        private Mqtt Mqtt_ = new Mqtt();
        SolidColorBrush colour = new SolidColorBrush();
        public Home()
        {
            this.InitializeComponent();

            Mqtt_.Client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(async e =>
            {
                var data = e.ApplicationMessage.ConvertPayloadToString();
                Console.WriteLine($"Topic is {e.ApplicationMessage.Topic} \n{data}");

                string topic = e.ApplicationMessage.Topic;

                var topicArray = topic.Split('/');
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    if (topicArray[2] == "SIG146548")
                    {
                        switch (topicArray[1])
                        {
                            case "TrafficDensity":
                                TrafficDensityRequest request = JsonConvert.DeserializeObject<TrafficDensityRequest>(data);
                                var v1 = request.Density;
                                chart1.Percentage = v1;
                                chart1.SegmentColor = choose_colour(v1);
                                h_tb.Text = ((int)v1).ToString() + "%";
                                break;

                            case "FusedTrafficDensity":
                                TrafficDensityRequest request1 = JsonConvert.DeserializeObject<TrafficDensityRequest>(data);
                                var v2 = request1.Density;
                                chart2.Percentage = v2;
                                chart2.SegmentColor = choose_colour(v2);
                                h_tb1.Text = ((int)v2).ToString() + "%";
                                break;
                        }
                    }
                }
                );


                

                
            });


        }

        private void update_chart(double v1)
        {
            
        }

        private Brush choose_colour(double percentage)
        {
            if (percentage <= 50)
            {
                colour = new SolidColorBrush(Colors.LawnGreen);
            }
            else if (percentage > 51 && percentage <= 80)
            {
                colour = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                colour = new SolidColorBrush(Colors.Red);
            }
            return colour;
        }
    }
}
