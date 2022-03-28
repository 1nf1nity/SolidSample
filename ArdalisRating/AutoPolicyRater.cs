namespace ArdalisRating;

internal class AutoPolicyRater : Rater
{
    public AutoPolicyRater(IRatingContext context) : base(context)
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
                Context.UpdateRating(1000m);
                return;
            }
            Context.UpdateRating(900m);
        }
    }
}