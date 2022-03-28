﻿namespace ArdalisRating;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Ardalis Insurance Rating System Starting...");

        var engine = new RatingEngine(new ConsoleLogger(), new TextPolicySource(), new JsonPolicySerializer());
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