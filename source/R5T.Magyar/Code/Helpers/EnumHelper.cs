using System;


namespace R5T.Magyar
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public static string UnrecognizedEnumerationValueMessage<TEnum>(string value)
            where TEnum : Enum // Requires C# 7.3.
        {
            var output = $@"Unrecognized enumeration value string '{value}' for enumeration {typeof(TEnum).FullName}";
            return output;
        }

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: This legacy method that restricts <typeparamref name="TEnum"/> as a struct, instead of an <see cref="Enum"/>, is provided since <see cref="Enum.TryParse{TEnum}(string, out TEnum)"/> restricts on struct instead of <see cref="Enum"/>.
        /// </summary>
        public static string UnrecognizedEnumerationValueMessageLegacy<TEnum>(string value)
            where TEnum : struct // Must be a struct for the moment, since Enum.TryParse<TEnum> requires TEnum to be a struct.
        {
            var output = $@"Unrecognized enumeration value string '{value}' for enumeration {typeof(TEnum).FullName}";
            return output;
        }

        /// <summary>
        /// Parses the string representation of an enumeration value to an value of the <typeparamref name="TEnum"/> enumeration.
        /// Note: this method restricts <typeparamref name="TEnum"/> as a struct, instead of an <see cref="Enum"/>, since <see cref="Enum.TryParse{TEnum}(string, out TEnum)"/> restricts on struct instead of <see cref="Enum"/>.
        /// </summary>
        public static TEnum Parse<TEnum>(string value)
            where TEnum : struct // Must be a struct for the moment, since Enum.TryParse<TEnum> requires TEnum to be a struct.
        {
            if (!Enum.TryParse(value, out TEnum output))
            {
                throw new Exception(EnumHelper.UnrecognizedEnumerationValueMessageLegacy<TEnum>(value));
            }

            return output;
        }

        /// <summary>
        /// Gets a message indicating the the input value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        /// <remarks>
        /// See: https://stackoverflow.com/questions/13645149/what-is-the-correct-exception-to-throw-for-unhandled-enum-values
        /// </remarks>
        public static string UnexpectedEnumerationValueMessage<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var output = $@"Unexpected enumeration value: '{value.ToString()}' for enumeration type {typeof(TEnum).FullName}";
            return output;
        }

        /// <summary>
        /// Gets all values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public static TEnum[] GetValues<TEnum>()
            where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum)) as TEnum[];
            return values;
        }
    }
}
