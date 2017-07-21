using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Rabbit_Console
{
    //class Program1
    //{
    //    static void Main(string[] args)
    //    {
    //        RabbitMqService rabbitMqService = new RabbitMqService();
    //        IConnection connection = rabbitMqService.GetRabbitMqConnection();
    //        IModel model = connection.CreateModel();
    //        IBasicProperties basicProperties = model.CreateBasicProperties();
    //        basicProperties.SetPersistent(false);
    //        byte[] payload = Encoding.UTF8.GetBytes("This is a message from Visual Studio");
    //        //Console.WriteLine(payload);
    //        PublicationAddress address = new PublicationAddress(ExchangeType.Topic, "exchangeFromVisualStudio", "superstars");
    //        model.BasicPublish(address, basicProperties, payload);
    //     }
    //    private static void SetupInitialTopicQueue(IModel model)
    //    {
    //        model.QueueDeclare("queueFromVisualStudio", true, false, false, null);
    //        model.ExchangeDeclare("exchangeFromVisualStudio", ExchangeType.Topic);
    //        model.QueueBind("queueFromVisualStudio", "exchangeFromVisualStudio", "superstars");
            
    //    }
    //}
}
