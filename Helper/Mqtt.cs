using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM_Frontend.Helper
{
    class Mqtt
    {
        public IMqttClient Client { get; set; }
        private IMqttClientOptions ClientOptions { get; set; }

        public Mqtt()
        {
            RegisterMqtt();
            ConnectMqqt();
        }

        private void RegisterMqtt()
        {
            var factory = new MqttFactory();
            Client = factory.CreateMqttClient();
            ClientOptions = new MqttClientOptionsBuilder()
                .WithClientId("FrontEndTestClient")
                .WithTcpServer("34.244.190.178")
                .Build();

            var PublishOptions = new MqttApplicationMessageBuilder()
                .WithTopic("MyTopic")
                .WithPayload("Hello World")
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            Client.ConnectedHandler = new MqttClientConnectedHandlerDelegate(e =>
            {
                Client.SubscribeAsync(new TopicFilterBuilder().WithTopic("#").Build());
            });
        }

        public void ConnectMqqt()
        {
            Task.Run(async () => { await Client.ConnectAsync(ClientOptions); });
        }
    }
}
