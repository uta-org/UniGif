using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using z3nth10n.EditorUtils;

namespace UnityGif.Editor
{
    public class GifFileEditor : UniGif.GifFile
    {
        public GifFileEditor(byte[] array)
        {
            data = SetDataFromEditor(array);
        }

        private UniGif.WrapperData SetDataFromEditor(byte[] array)
        {
            return UniGifWrapperEditor.LoadFromEditor(array);
        }

        public void DrawFromEditor(Rect r, xEditorGUI xEditorGUI, float maxWidth = 200)
        {
            if (data != null)
            {
                Vector2 v = RedimGif(data, maxWidth);

                r.x += (Screen.width - maxWidth) / 2;
                r.width = v.x;
                r.height = v.y;

                _Draw(r, data);
                xEditorGUI.UpdateHeight(r.y);
            }
            else
                Debug.LogWarning("Something unexpected happened!");
        }

        private void _Draw(Rect r, UniGif.WrapperData data)
        {
            if (data == null)
                return;

            if (data != null && data.list != null && data.list.Count > 0)
                GUI.DrawTexture(r, data.NextFrame());
        }

        private static Vector2 RedimGif(UniGif.WrapperData data, float maxWidth)
        {
            return new Vector2(maxWidth, data.height * (maxWidth / data.width));
        }
    }
}