using System;


namespace R5T.Magyar
{
    /// <summary>
    /// Indicates that the instance returned by a function is a different instance than provided to the function. The function re-instantiated the instance.
    /// By convention, reference types are mutated by fluent operations (meaning the output instance is the same as the input instance), while value types are re-instantiated by fluent operations (meaning the output instance is a different instance from the input instance).
    /// This attribute should be applied to functions that break these conventions, but can also be applied to functions following these conventions to provide the comfort of certainty in communication.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
    public class ImmutableFluencyAttribute : Attribute
    {
    }
}
