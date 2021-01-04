using System;

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

            int lenght = array.Length;
            int[] preSum = new int[lenght];
            preSum[0] = array[0];
            for (int i = 1; i < lenght; i++)
            {
                preSum[i] = preSum[i - 1] + array[i];
            }

            int[] sufSum = new int[lenght];
            sufSum[lenght - 1] = array[lenght - 1];
            for (int i = lenght - 2; i >= 0; i--)
            {
                sufSum[i] = sufSum[i + 1] + array[i];
            }

            for (int i = 1; i < lenght - 1; i++)
            {
                if (preSum[i] == sufSum[i])
                {
                    return i;
                }
            }

            return null;
        }
    }
}
