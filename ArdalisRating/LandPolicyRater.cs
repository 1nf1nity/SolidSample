namespace ArdalisRating;

internal class LandPolicyRater : Rater
{
    public LandPolicyRater(IRatingContext context) : base(context)
    {
    }

    public override void Rate(Policy policy)
    {
        Context.Log("Rating LAND policy...");
        Context.Log("Validating policy.");

        if (policy.BondAmount == 0 || policy.Valuation == 0)
        {
            Context.Log("Land policy must specify Bond Amount and Valuation.");
            return;
        }

        if (policy.BondAmount < 0.8m * policy.Valuation)
        {
            Context.Log("Insufficient bond amount.");
            return;
        }

        Context.UpdateRating(policy.BondAmount * 0.05m);
    }
}