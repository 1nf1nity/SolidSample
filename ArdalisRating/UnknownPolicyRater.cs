namespace ArdalisRating;

internal class UnknownPolicyRater : Rater
{
    public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger) : base(engine, logger)
    {
    }

    public override void Rate(Policy policy)
    {
        Logger.Log("Unknown policy type");
    }
}