namespace ArdalisRating;

internal class AutoPolicyRater : Rater
{
    public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
    {
    }

    public override void Rate(Policy policy)
    {
        Logger.Log("Rating AUTO policy...");
        Logger.Log("Validating policy.");

        if (string.IsNullOrEmpty(policy.Make))
        {
            Logger.Log("Auto policy must specify Make");
            return;
        }

        if (policy.Make == "BMW")
        {
            if (policy.Deductible < 500)
            {
                Engine.Rating = 1000m;
                return;
            }
            Engine.Rating = 900m;
        }
    }
}