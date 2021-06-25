using System;


namespace R5T.Magyar
{
    public interface ILabeler<TValue, TLabel>
    {
        TLabel Label(TValue value);
    }


    public interface ILabeler<TValue> : ILabeler<TValue, string>
    {
    }
}
