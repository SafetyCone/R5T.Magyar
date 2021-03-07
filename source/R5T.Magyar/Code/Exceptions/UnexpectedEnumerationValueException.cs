using System;
using System.Runtime.Serialization;


namespace R5T.Magyar
{
    public class UnexpectedEnumerationValueException<TEnum> : Exception
        where TEnum: Enum
    {
        protected const string ValuePropertyName = "Value";


        public TEnum Value { get; }


        public UnexpectedEnumerationValueException()
            : base()
        {
        }

        public UnexpectedEnumerationValueException(string message)
            : base(message)
        {
        }

        public UnexpectedEnumerationValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnexpectedEnumerationValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            var valueStringRepresentation = info.GetString(UnexpectedEnumerationValueException<TEnum>.ValuePropertyName);

            this.Value = EnumerationHelper.GetValue<TEnum>(valueStringRepresentation);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(UnexpectedEnumerationValueException<TEnum>.ValuePropertyName, this.Value.ToString());
        }

        public UnexpectedEnumerationValueException(TEnum value)
            : this(EnumerationHelper.UnexpectedEnumerationValueMessage<TEnum>(value))
        {
            this.Value = value;
        }

        public UnexpectedEnumerationValueException(TEnum value, string message)
            : this(message)
        {
            this.Value = value;
        }

        public UnexpectedEnumerationValueException(TEnum value, string message, Exception innerException)
            : this(message, innerException)
        {
            this.Value = value;
        }
    }
}
