namespace ArdalisRating;

internal class AutoPolicyRater : Rater
{
    public AutoPolicyRater(IRatingContext context) : base(context)
    {
    }

    public override void Rate(Policy policy)
    {
        Context.Log("Rating AUTO policy...");
        Context.Log("Validating policy.");

        if (string.IsNullOrEmpty(policy.Make))
        {
            Context.Log("Auto policy must specify Make");
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