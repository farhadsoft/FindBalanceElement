using System;
using System.Collections.Generic;

namespace FindBalanceElementTask
{
    /// <summary>
    /// Class for operations with arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds an index of element in an integer array for which the sum of the elements
        /// on the left and the sum of the elements on the right are equal.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>The index of the balance element, if it exists, and null otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty.</exception>
        public static int? FindBalanceElement(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"Thrown when source array is null. {nameof(array)}");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Thrown when source array is empty.");
            }

            int length = array.Length;
            int[] preSum = new int[length];
            preSum[0] = array[0];
            for (int i = 1; i < length; i++)
            {
                preSum[i] = preSum[i - 1] + array[i];
            }

            int[] sufsum = new int[length];
            sufsum[length - 1] = array[length - 1];
            for (int i = length - 2; i >= 0; i--)
            {
                sufsum[i] = sufsum[i + 1] + array[i];
            }

            for (int i = 1; i < length - 1; i++)
            {
                if (preSum[i] == sufsum[i])
                {
                    return i;
                }
            }

            return null;
        }
    }
}
