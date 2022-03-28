﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating;

public class JsonPolicySerializer : IPolicySerializer
{
    public Policy GetPolicyFromString(string policyJson)
    {
        return JsonConvert.DeserializeObject<Policy>(policyJson,
            new StringEnumConverter());
    }
}