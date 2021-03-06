﻿using System.Collections;
using UnityEngine;

namespace UnityGif
{
    /// <summary>
    ///     Extension methods class
    /// </summary>
    public static class UniGifExtension
    {
        /// <summary>
        ///     Convert BitArray to int (Specifies the start index and bit length)
        /// </summary>
        /// <param name="startIndex">Start index</param>
        /// <param name="bitLength">Bit length</param>
        /// <returns>Converted int</returns>
        public static int GetNumeral(this BitArray array, int startIndex, int bitLength)
        {
            var newArray = new BitArray(bitLength);

            for (var i = 0; i < bitLength; i++)
                if (array.Length <= startIndex + i)
                {
                    newArray[i] = false;
                }
                else
                {
                    var bit = array.Get(startIndex + i);
                    newArray[i] = bit;
                }

            return newArray.ToNumeral();
        }

        //#if !UNITY_2020 && !UNITY_2019 && !UNITY_2018 && !UNITY_2017 && !UNITY_5

        /// <summary>
        ///     Convert BitArray to int
        /// </summary>
        /// <returns>Converted int</returns>
        public static int ToNumeral(this BitArray array)
        {
            if (array == null)
            {
                Debug.LogError("array is nothing.");
                return 0;
            }

            if (array.Length > 32)
            {
                Debug.LogError("must be at most 32 bits long.");
                return 0;
            }

            var result = new int[1];
            array.CopyTo(result, 0);
            return result[0];
        }

        //#endif
    }
}
