using System;

namespace UnityGif.Editor
{
    public class UniGifWrapperEditor
    {
        private static UniGif.WrapperData InternalCallbackEditor(byte[] bytes)
        {
            UniGif.WrapperData wrapperData = new UniGif.WrapperData();

            var num = UniGif.GetTextureListCoroutine(bytes, (gtList, loop, w, h) =>
            {
                wrapperData.list = gtList;
                wrapperData.width = w;
                wrapperData.height = h;
            }, wrapperData.filterMode, wrapperData.wrapMode, wrapperData.outputDebugLog);

            while (num.MoveNext())
            {
            }

            return wrapperData;
        }

        public static UniGif.WrapperData LoadFromEditor(byte[] array)
        {
            if (array == null)
                throw new ArgumentException("array");

            return InternalCallbackEditor(array);
        }
    }
}