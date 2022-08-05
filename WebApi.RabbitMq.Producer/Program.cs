using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebApi.RabbitMq.Producer
{
    public class LoanRequest
    {
        public string Instance { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal LoanAmount { get; set; }
        public int NumberOfInstallments { get; set; }
    }

    public class Program
    {
        private static string RandomString(int length)
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        private static List<LoanRequest> GetList(string instance)
        {
            Random rnd = new Random();
            List<LoanRequest> list = new();

            int loanCouunt = rnd.Next(14, 30);
            for (int i = 0; i < loanCouunt; i++)
            {
                list.Add(new LoanRequest
                {
                    Instance = instance,
                    ID = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10),
                    Name = $"{RandomString(5)}",
                    SurName = $"{RandomString(7)}",
                    BirthDate = new DateTime(rnd.Next(1945, 1999), rnd.Next(1, 12), rnd.Next(1, 12)),
                    LoanAmount = rnd.Next(1000, 100000),
                    NumberOfInstallments = rnd.Next(5, 60)
                });
            }
            return list;
        }
        static void Main(string[] args)
        {
            string InstanceID = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Loan", durable: false, exclusive: false, autoDelete: false, arguments: null);

                Console.WriteLine($"Sending Loans from Server={InstanceID}");
                var list = GetList(InstanceID);
                foreach (LoanRequest item in list)
                {
                    string message = JsonConvert.SerializeObject(item);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "Loan", basicProperties: null, body: body);

                    Console.WriteLine($"Server= {InstanceID} LoanID ={item.ID} : {item.Name}-{item.SurName}  - Loan {item.LoanAmount}/{item.NumberOfInstallments}");
                    Thread.Sleep(3000);
                }
            }

            Console.WriteLine("All Loans Sent ...");
            Console.ReadLine();
        }
    }
}