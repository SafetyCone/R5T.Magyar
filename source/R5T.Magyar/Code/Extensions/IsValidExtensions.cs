using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;


namespace System
{
    public static class IsValidExtensions
    {
        public static bool AnyReasonsWhyInvalid(this IsValid isValid)
        {
            var output = isValid.ReasonsWhyInvalid?.Any() ?? false;
            return output;
        }

        public static string GetReasonsWhyInvalidText(this IsValid isValid)
        {
            var anyReasonsWhyInvalid = isValid.AnyReasonsWhyInvalid();
            if(anyReasonsWhyInvalid)
            {
                var output = String.Join(Environment.NewLine, isValid.ReasonsWhyInvalid);
                return output;
            }
            else
            {
                return String.Empty;
            }
        }

        public static string ReasonWhyInvalid(this IsValid isValid)
        {
            var output = isValid.ReasonsWhyInvalid?.FirstOrDefault() ?? default;
            return output;
        }

        public static void AddReasonsToList(this IsValid isValid, List<string> reasons)
        {
            var anyReasonsWhyInvalid = isValid.AnyReasonsWhyInvalid();
            if(anyReasonsWhyInvalid)
            {
                reasons.AddRange(isValid.ReasonsWhyInvalid);
            }
        }
    }
}
