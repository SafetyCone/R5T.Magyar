using System;


namespace R5T.Magyar
{
    public enum DuplicateValueHandling
    {
        // Default is to assume duplicate values are an error.
        Error = 0,

        KeepFirst,
        UseLast
        // No more 
    }


    public static class DuplicateValueHandlingExtensions
    {
        /// <summary>
        /// Note: assumes that <paramref name="existing"/> and <paramref name="duplicate"/> have already been determined to be duplicates.
        /// This method just follows the "try-" pattern and informs as to whether choosing a duplicate would succeed, or if an exception would be thrown based on the <see cref="DuplicateValueHandling"/> value.
        /// In case of false, the output <paramref name="chosen"/> value is the default value of <typeparamref name="TValue"/>.
        /// In case of true, the chosen value is either the existing (<see cref="DuplicateValueHandling.KeepFirst"/>) or duplicate (<see cref="DuplicateValueHandling.UseLast"/>) value depending on the value of <paramref name="duplicateValueHandling"/>.
        /// </summary>
        public static bool TryChoose<TValue>(this DuplicateValueHandling duplicateValueHandling,
            TValue existing,
            TValue duplicate,
            out TValue chosen)
        {
            if(duplicateValueHandling == DuplicateValueHandling.Error)
            {
                chosen = default;

                return false;
            }

            if(duplicateValueHandling == DuplicateValueHandling.KeepFirst)
            {
                chosen = existing;
            }
            else // Use last.
            {
                chosen = duplicate;
            }

            return true;
        }

        /// <summary>
        /// Note: assumes that <paramref name="existing"/> and <paramref name="duplicate"/> have already been determined to be duplicates.
        /// This method is meant for use in an if()-block, and informs as to whether choosing a duplicate would succeed, or if an exception would be thrown based on the <see cref="DuplicateValueHandling"/> value.
        /// In case of false, the output <paramref name="chosen"/> value is the default value of <typeparamref name="TValue"/>.
        /// In case of true, the chosen value is either the existing (<see cref="DuplicateValueHandling.KeepFirst"/>) or duplicate (<see cref="DuplicateValueHandling.UseLast"/>) value depending on the value of <paramref name="duplicateValueHandling"/>.
        /// </summary>
        public static bool ChooseWouldFail<TValue>(this DuplicateValueHandling duplicateValueHandling,
            TValue existing,
            TValue duplicate,
            out TValue chosen)
        {
            if (duplicateValueHandling == DuplicateValueHandling.Error)
            {
                chosen = default;

                return true;
            }

            if (duplicateValueHandling == DuplicateValueHandling.KeepFirst)
            {
                chosen = existing;
            }
            else // Use last.
            {
                chosen = duplicate;
            }

            return false;
        }

        public static TValue Choose<TValue>(this DuplicateValueHandling duplicateValueHandling,
            TValue existing,
            TValue duplicate)
        {
            if(duplicateValueHandling.ChooseWouldFail(existing, duplicate, out TValue chosen))
            {
                throw new DuplicateValueException<TValue>(existing, duplicate);
            }

            return chosen;
        }
    }
}
