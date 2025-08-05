using Grpc.Core;

namespace CalculatorService
{
    public class CalculatorServiceImpl : Calculator.Calculator.CalculatorBase
    {
        public override Task<Calculator.AddResponse> Add(Calculator.AddRequest request, ServerCallContext context)
        {
            var response = new Calculator.AddResponse
            {
                Result = request.Num1 + request.Num2
            };
            return Task.FromResult(response);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add gRPC
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<CalculatorServiceImpl>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}
