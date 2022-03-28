using ArdalisRating.Models;

namespace ArdalisRating.PolicySerializers;

public interface IPolicySerializer
{
    Policy GetPolicyFromString(string policyString);
}