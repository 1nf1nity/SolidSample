namespace ArdalisRating;

public class AutoPolicyRater : Rater
{
    public AutoPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater)
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
                RatingUpdater.UpdateRating(1000m);
                return;
            }
            RatingUpdater.UpdateRating(900m);
        }
    }
}