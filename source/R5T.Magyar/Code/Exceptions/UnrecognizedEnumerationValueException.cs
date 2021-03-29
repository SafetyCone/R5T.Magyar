﻿using System;
using System.Runtime.Serialization;


namespace R5T.Magyar
{
    /// <summary>
    /// An exception for when where the string representation of a enumeration value is unrecognizable as one of the values of the enumeration.
    /// Useful in the default case of a switch statement for parsing a string to an enumeration.
    /// </summary>
    public class UnrecognizedEnumerationValueException : Exception
    {
        private const string EnumerationTypeFullNamePropertyName = "EnumerationTypeName";
        private const string UnrecognizedValuePropertyName = "UnrecogizedValue";


        #region Static

        public static UnrecognizedEnumerationValueException From<T>(string unrecognizedValue, string message)
        {
            var enumerationTypeFullName = typeof(T).FullName;

            var exception = new UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue, message);
            return exception;
        }

        public static UnrecognizedEnumerationValueException From<T>(string unrecognizedValue)
            where T: Enum
        {
            var message = EnumerationHelper.UnrecognizedEnumerationValueMessage<T>(unrecognizedValue);

            var exception = UnrecognizedEnumerationValueException.From<T>(unrecognizedValue, message);
            return exception;
        }

        #endregion


        public string EnumerationTypeFullName { get; }
        public string UnrecognizedValue { get; }


        public UnrecognizedEnumerationValueException()
        {
        }

        public UnrecognizedEnumerationValueException(string message)
            : base(message)
        {
        }

        public UnrecognizedEnumerationValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnrecognizedEnumerationValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.EnumerationTypeFullName = info.GetString(UnrecognizedEnumerationValueException.EnumerationTypeFullNamePropertyName);
            this.UnrecognizedValue = info.GetString(UnrecognizedEnumerationValueException.UnrecognizedValuePropertyName);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(UnrecognizedEnumerationValueException.EnumerationTypeFullNamePropertyName, this.EnumerationTypeFullName);
            info.AddValue(UnrecognizedEnumerationValueException.UnrecognizedValuePropertyName, this.UnrecognizedValue);
        }

        public UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue)
            : this(EnumerationHelper.UnrecognizedEnumerationValueMessage(enumerationTypeFullName, unrecognizedValue))
        {
            this.EnumerationTypeFullName = enumerationTypeFullName;
            this.UnrecognizedValue = unrecognizedValue;
        }

        public UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue, string message)
            : this(message)
        {
            this.EnumerationTypeFullName = enumerationTypeFullName;
            this.UnrecognizedValue = unrecognizedValue;
        }

        public UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue, string message, Exception innerException)
            : base(message, innerException)
        {
            this.EnumerationTypeFullName = enumerationTypeFullName;
            this.UnrecognizedValue = unrecognizedValue;
        }
    }
}
