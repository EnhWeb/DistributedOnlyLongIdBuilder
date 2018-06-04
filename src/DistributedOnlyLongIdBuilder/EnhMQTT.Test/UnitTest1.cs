using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MQTTnet;
using MQTTnet.Core.Protocol;
using MQTTnet.Core.Server;

namespace EnhMQTT.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
