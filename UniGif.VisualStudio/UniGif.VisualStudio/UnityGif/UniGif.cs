/*
UniGif
Copyright (c) 2015 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Extensions;
using uzLib.Lite.ExternalCode.Extensions;

namespace UnityGif
{
    public static partial class UniGif
    {
        /// <summary>
        ///     Get GIF texture list Coroutine
        /// </summary>
        /// <param name="bytes">GIF file byte data</param>
        /// <param name="callback">
        ///     Callback method(param is GIF texture list, Animation loop count, GIF image width (px), GIF image
        ///     height (px))
        /// </param>
        /// <param name="thisReference">The this reference.</param>
        /// <param name="mono">The mono.</param>
        /// <param name="filterMode">Textures filter mode</param>
        /// <param name="wrapMode">Textures wrap mode</param>
        /// <param name="debugLog">Debug Log Flag</param>
        /// <returns>
        ///     IEnumerator
        /// </returns>
        /// <exception cref="ArgumentNullException">mono</exception>
        public static IEnumerator GetTextureListCoroutine(
            byte[] bytes,
            Action<List<GifTexture>, int, int, int> callback,
            object thisReference,
            MonoBehaviour mono,
            FilterMode filterMode = FilterMode.Bilinear,
            TextureWrapMode wrapMode = TextureWrapMode.Clamp,
            bool debugLog = false)
        {
            var isEditor = thisReference != null;

            if (mono == null)
                throw new ArgumentNullException(nameof(mono));

            var loopCount = -1;

            var width = 0;
            var height = 0;

            // Set GIF data
            var gifData = new GifData();

            if (!SetGifData(bytes, ref gifData, debugLog))
            {
                Debug.LogError("GIF file data set error.");
                callback?.Invoke(null, loopCount, width, height);

                yield break;
            }

            // Decode to textures from GIF data
            List<GifTexture> gifTexList = null;

            yield return gifData.DecodeTextureCoroutine(result => gifTexList = result, filterMode, wrapMode, isEditor)
                .CreateSmartCorotine(thisReference, mono);

            if (gifTexList == null || gifTexList.Count <= 0)
            {
                Debug.LogError(
                    $"GIF texture decode error. Count: {gifTexList.PrintListLength()} || Byte Count: {bytes?.Length}");
                callback?.Invoke(null, loopCount, width, height);

                yield break;
            }

            if (gifData.IsNull())
                throw new NullReferenceException();

            loopCount = gifData.m_appEx.loopCount;
            width = gifData.m_logicalScreenWidth;
            height = gifData.m_logicalScreenHeight;

            callback?.Invoke(gifTexList, loopCount, width, height);
        }
    }
}