using System;


namespace System
{
    using R5T.Magyar;


    public static class BooleanExtensions
    {
        public static string YesOrNo(this bool value)
        {
            var output = value
                ? Instances.Word.Yes()
                : Instances.Word.No();

            return output;
        }
    }
}


namespace R5T.Magyar
{
    public static class BooleanExtensions
    {
        public static bool ValueOrFalse(this bool? nullableValue)
        {
            if (nullableValue.HasValue)
            {
                return nullableValue.Value;
            }
            else
            {
                return false;
            }
        }
    }
}


namespace R5T.Magyar.Extensions
{
    public static class BooleanExtensions
    {
        public static string ToStringAllCapitals(this bool value)
        {
            var representation = value
                ? "TRUE"
                : "FALSE"
                ;
            return representation;
        }
    }
}
