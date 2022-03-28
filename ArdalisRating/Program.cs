using ArdalisRating.Loggers;
using ArdalisRating.PolicySerializers;
using ArdalisRating.PolicySources;
using ArdalisRating.Raters;

namespace ArdalisRating;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Ardalis Insurance Rating System Starting...");

        var logger = new ConsoleLogger();
        var engine = new RatingEngine(logger, new TextPolicySource(), new JsonPolicySerializer(), new RaterFactory(logger));
        
        engine.Rate();

        if (engine.Rating > 0)
        {
            Console.WriteLine($"Rating: {engine.Rating}");
        }
        else
        {
            Console.WriteLine("No rating produced.");
        }

    }
}