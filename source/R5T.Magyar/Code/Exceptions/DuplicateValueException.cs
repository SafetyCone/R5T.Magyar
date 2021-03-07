using System;
//using System.Runtime.Serialization;


namespace R5T.Magyar
{
    public class DuplicateValueException : Exception
    {
        #region Static

        public static string GetMessage<TValue>(TValue existing, TValue duplicate)
        {
            var message = $"";
            return message;
        }

        #endregion


        public DuplicateValueException()
            : base()
        {
        }

        public DuplicateValueException(string message)
            : base(message)
        {
        }

        public DuplicateValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }


    public class DuplicateValueException<TValue> : Exception
    {
        protected const string ExistingPropertyName = "Existing";
        protected const string DuplicatePropertyName = "Duplicate";


        public TValue Existing { get; }
        public TValue Duplicate { get; }


        public DuplicateValueException()
            : base()
        {
        }

        public DuplicateValueException(string message)
            : base(message)
        {
        }

        public DuplicateValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DuplicateValueException(TValue existing, TValue duplicate)
            : this(DuplicateValueException.GetMessage<TValue>(existing, duplicate))
        {
            this.Existing = existing;
            this.Duplicate = duplicate;
        }

        public DuplicateValueException(TValue existing, TValue duplicate, string message)
            : this(message)
        {
            this.Existing = existing;
            this.Duplicate = duplicate;
        }

        public DuplicateValueException(TValue existing, TValue duplicate, string message, Exception innerException)
            : this(message, innerException)
        {
            this.Existing = existing;
            this.Duplicate = duplicate;
        }

        //protected DuplicateValueException(SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{
        //    var existingStringRepresentation = info.GetString(DuplicateValueException<TValue>);

        //    this.Value = EnumerationHelper.GetValue<TValue>(valueStringRepresentation);
        //}

        //public override void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    base.GetObjectData(info, context);

        //    info.AddValue(UnexpectedEnumerationValueException<TValue>.ValuePropertyName, this.Value.ToString());
        //}
    }
}
