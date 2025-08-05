using Grpc.Net.Client;

namespace CalculatorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:65383");
            var client = new Calculator.Calculator.CalculatorClient(channel);

            Console.WriteLine("Enter first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int num2 = int.Parse(Console.ReadLine());

            var response = await client.AddAsync(
                new Calculator.AddRequest { Num1 = num1, Num2 = num2 });

            Console.WriteLine($"Result: {response.Result}");
        }
    }
}
