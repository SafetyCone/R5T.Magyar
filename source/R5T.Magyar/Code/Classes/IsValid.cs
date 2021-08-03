using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.Magyar
{
    public class IsValid
    {
        #region Static

        public static string NullReason => null;
        public static string[] NullReasons => Array.Empty<string>();


        public static IsValid Combine(params IsValid[] values)
        {
            var isValid = true;
            var reasons = new List<string>();

            foreach (var value in values)
            {
                isValid = isValid && value;

                if(value.ReasonsWhyInvalid?.Any() ?? false)
                {
                    reasons.AddRange(value.ReasonsWhyInvalid);
                }
            }

            var output = new IsValid(isValid, reasons.ToArray());
            return output;
        }

        public static IsValid From(bool isValid, string reasonIfInvalid)
        {
            var reason = isValid
                ? IsValid.NullReason
                : reasonIfInvalid
                ;

            var output = new IsValid(isValid, ArrayHelper.From(reason));
            return output;
        }

        public static IsValid From(bool isValid, IEnumerable<string> reasonsWhyInvalid)
        {
            var reasons = isValid
                ? IsValid.NullReasons
                : reasonsWhyInvalid.ToArray();

            var output = new IsValid(isValid, reasons);
            return output;
        }

        public static IsValid Valid()
        {
            var output = new IsValid(true, ArrayHelper.From(IsValid.NullReason));
            return output;
        }

        public static IsValid Invalid(string reasonWhyInvalid)
        {
            var output = new IsValid(false, ArrayHelper.From(reasonWhyInvalid));
            return output;
        }

        public static IsValid Invalid(IEnumerable<string> reasonsWhyInvalid)
        {
            var output = new IsValid(false, reasonsWhyInvalid.ToArray());
            return output;
        }

        public static implicit operator bool(IsValid isValid)
        {
            return isValid.Validity;
        }

        #endregion


        public bool Validity { get; }
        public string[] ReasonsWhyInvalid { get; }


        public IsValid(bool validity, string[] reasonsWhyInvalid)
        {
            this.Validity = validity;
            this.ReasonsWhyInvalid = reasonsWhyInvalid;
        }
    }
}
