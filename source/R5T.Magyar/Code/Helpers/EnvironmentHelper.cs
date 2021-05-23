using System;


namespace R5T.Magyar
{
    public static class EnvironmentHelper
    {
        public const string EnvironmentVariableNotFoundValue = null;


        public static bool IsEnvironmentVariableFound(string environmentVariableValue)
        {
            var output = environmentVariableValue != EnvironmentHelper.EnvironmentVariableNotFoundValue;
            return output;
        }
    }
}
