using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7110");

var client = new Greeter.GreeterClient(channel);

do
{
    Console.WriteLine("Input your string human:");

    var rawString = Console.ReadLine();

    var reply = await client.ChangeToLowercaseAsync(new RawStringRequest { RawString = rawString });

    Console.WriteLine($"Greeter service says: { reply.RawString }");

    Console.WriteLine("Press Q to quite or any othe key to continue.");

} while (Console.ReadKey().Key != ConsoleKey.Q);



