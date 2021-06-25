using System;


namespace System
{
    public delegate T Modifier<T>(T value);
    public delegate T ModifierWith<T, TData>(T value, TData data);
}


namespace System.Collections.Generic
{
    public delegate IEnumerable<T> Selector<T>(IEnumerable<T> items);
}
