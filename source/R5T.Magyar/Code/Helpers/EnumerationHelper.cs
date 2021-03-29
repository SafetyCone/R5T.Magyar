using System;
using System.Linq;


namespace R5T.Magyar
{
    public static class EnumerationHelper
    {
        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the enumeration type.
        /// </summary>
        public static string UnrecognizedEnumerationValueMessage(string enumerationTypeFullName, string unrecognizedValue)
        {
            var output = $@"Unrecognized enumeration value string '{unrecognizedValue}' for enumeration type {enumerationTypeFullName}";
            return output;
        }

        public static string UnrecognizedEnumerationValueMessage(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var output = EnumerationHelper.UnrecognizedEnumerationValueMessage(enumerationTypeFullName, unrecognizedValue);
            return output;
        }

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public static string UnrecognizedEnumerationValueMessage<TEnum>(string unrecognizedValue)
            where TEnum : Enum // Requires C# 7.3.
        {
            var enumerationType = typeof(TEnum);

            var output = EnumerationHelper.UnrecognizedEnumerationValueMessage(enumerationType, unrecognizedValue);
            return output;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationTypeFullName"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public static UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue)
        {
            var unrecognizedEnumerationValueException = new UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationType"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public static UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var unrecognizedEnumerationValueException = EnumerationHelper.UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <typeparamref name="TEnum"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public static UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException<TEnum>(string unrecognizedValue)
            where TEnum: Enum
        {
            var enumerationType = typeof(TEnum);

            var unrecognizedEnumerationValueException = EnumerationHelper.UnrecognizedEnumerationValueException(enumerationType, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <typeparamref name="TEnum"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public static UnrecognizedEnumerationValueException RepresentationUnrecognizedException<TEnum>(string unrecognizedRepresentation)
            where TEnum : Enum
        {
            var output = EnumerationHelper.UnrecognizedEnumerationValueException<TEnum>(unrecognizedRepresentation);
            return output;
        }

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: This legacy method that restricts <typeparamref name="TEnum"/> as a struct, instead of an <see cref="Enum"/>, is provided since <see cref="Enum.TryParse{TEnum}(string, out TEnum)"/> restricts on struct instead of <see cref="Enum"/>.
        /// </summary>
        public static string UnrecognizedEnumerationValueMessageLegacy<TEnum>(string unrecognizedValue)
            where TEnum : struct // Must be a struct for the moment, since Enum.TryParse<TEnum> requires TEnum to be a struct.
        {
            var output = $@"Unrecognized enumeration value string '{unrecognizedValue}' for enumeration {typeof(TEnum).FullName}";
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
                throw new Exception(EnumerationHelper.UnrecognizedEnumerationValueMessageLegacy<TEnum>(value));
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
        public static string UnexpectedEnumerationValueMessage<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = $@"Unexpected enumeration value: '{unexpectedValue.ToString()}' for enumeration type {typeof(TEnum).FullName}";
            return output;
        }

        /// <summary>
        /// Produces an exception for the situation where a value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        public static UnexpectedEnumerationValueException<TEnum> UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum: Enum
        {
            var unexpectedEnumerationValueException = new UnexpectedEnumerationValueException<TEnum>(unexpectedValue);
            return unexpectedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception for use in the default case of a switch statement based on values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public static UnexpectedEnumerationValueException<TEnum> SwitchDefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var exception = EnumerationHelper.UnexpectedEnumerationValueException(value);
            return exception;
        }

        /// <summary>
        /// Gets all values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public static TEnum[] GetValues<TEnum>()
            where TEnum : Enum
        {
            // Alternate implementation using LINQ: https://stackoverflow.com/questions/972307/how-to-loop-through-all-enum-values-in-c

            var values = Enum.GetValues(typeof(TEnum)) as TEnum[];
            return values;
        }

        public static TEnum GetValue<TEnum>(string valueString)
            where TEnum: Enum
        {
            var value = (TEnum)Enum.Parse(typeof(TEnum), valueString);
            return value;
        }
    }
}
