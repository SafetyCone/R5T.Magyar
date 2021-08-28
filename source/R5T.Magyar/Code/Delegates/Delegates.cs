using System;
using System.Threading.Tasks;


namespace System
{
    public delegate T ModifierSynchronous<T>(T value);
    public delegate T ModifierSynchronousWith<T, TData>(T value, TData data);
}


namespace System.Collections.Generic
{
    public delegate IEnumerable<T> Selector<T>(IEnumerable<T> items);
}


namespace R5T.Magyar
{
    public delegate Task<T> Modifier<T>(T value);
}
