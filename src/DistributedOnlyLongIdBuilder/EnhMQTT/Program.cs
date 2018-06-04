using MQTTnet;
using MQTTnet.Core;
using MQTTnet.Core.Client;
using MQTTnet.Core.Packets;
using MQTTnet.Core.Protocol;
using MQTTnet.Core.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhMQTT
{
    class Program
    {
        static void Main(string[] args)
        {
           // StartServer();
            ConnectionServer();

            Console.ReadKey();
        }

        static void ConnectionServer()
        {
            var options = new MqttClientTcpOptions
            {
               // Port = 61613,
                Server = "127.0.0.1",
                ClientId = "c001",
                UserName = "u001",
                Password = "p001",
                CleanSession = true
            };


            var mqttClient = new MqttClientFactory().CreateMqttClient();

            mqttClient.ConnectAsync(options);

            mqttClient.SubscribeAsync(new List<TopicFilter> {
                new TopicFilter("家/客厅/空调/#", MqttQualityOfServiceLevel.AtMostOnce)
            });

            var appMsg = new MqttApplicationMessage("家/客厅/空调/开关", Encoding.UTF8.GetBytes("消息内容"), MqttQualityOfServiceLevel.AtMostOnce, false);

            mqttClient.PublishAsync(appMsg);

        }



        static void StartServer()
        {
            var options = new MqttServerOptions
            {
                ConnectionValidator = c =>
                {
                    if (c.ClientId.Length < 10)
                    {
                        return MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    }

                    if (c.Username != "xxx" || c.Password != "xxx")
                    {
                        return MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    }

                    return MqttConnectReturnCode.ConnectionAccepted;
                }
            };

            var mqttServer = new MqttServerFactory().CreateMqttServer(options);

            mqttServer.StartAsync();
        }
    }
}
