using CielaSpike;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityGif
{
    public static partial class UniGif
    {
        [Serializable]
        public class GifFile
        {
            public string path;

            [NonSerialized]
            public WrapperData data;

            private bool isLoading;

            private Rect myRect;
            private MonoBehaviour mono;

            public GifFile()
            {
            }

            public GifFile(byte[] array)
            {
                data = SetDataFromEditor(array);
            }

            public GifFile(string path)
            {
                this.path = path;
            }

            public bool FlagAsLoaded()
            {
                bool il = isLoading;

                isLoading = true;

                return il;
            }

            public void SetMono(MonoBehaviour mono)
            {
                this.mono = mono;
            }

            public void Draw(int xMin, int yMin)
            {
                SetData();

                if (data == null)
                    return;

                if (myRect == default(Rect))
                    myRect = new Rect(xMin, yMin, data.width, data.height);

                _Draw();
            }

            public void Draw(Rect rect)
            {
                SetData();

                if (data == null)
                    return;

                if (myRect == default(Rect))
                    myRect = rect;

                _Draw();
            }

            public void Draw()
            {
                SetData();

                if (data == null)
                    return;

                if (myRect == default(Rect))
                    myRect = new Rect(0, 0, data.width, data.height);

                _Draw();
            }

            private void SetData()
            {
                if (mono == null)
                    throw new Exception("Must call 'SetMono' before call drawing!");

                if (data == null)
                {
                    if (!gifTexDict.ContainsKey(path))
                    {
                        if (!FlagAsLoaded())
                            LoadFrom(mono, this);
                    }
                    else
                    {
                        if (data == null)
                            data = gifTexDict[path];
                    }
                }
            }

            private void _Draw()
            {
                UniGif.Draw(myRect, data);
            }

            public void DrawFromEditor(Rect r)
            {
                if (data != null)
                    UniGif.Draw(r, data);
                else
                    Debug.LogWarning("Something unexpected happened!");
            }

            private WrapperData SetDataFromEditor(byte[] array)
            {
                return LoadFromEditor(array);
            }
        }

        public class WrapperData
        {
            public List<GifTexture> list;
            public int width, height, loop;

            public FilterMode filterMode = FilterMode.Point;
            public TextureWrapMode wrapMode = TextureWrapMode.Clamp;
            public bool outputDebugLog = false;

            private int _ind;
            private float _time;

            public WrapperData()
            {
            }

            public WrapperData(FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Clamp, bool outputDebugLog = false)
            {
                this.filterMode = filterMode;
                this.wrapMode = wrapMode;
                this.outputDebugLog = outputDebugLog;
            }

            public WrapperData(List<GifTexture> list, int width, int height, int loop = 0)
            {
                this.list = list;
                this.width = width;
                this.height = height;
                this.loop = loop;
            }

            public Texture2D NextFrame()
            {
                if (_ind == list.Count - 1)
                    _ind = 0;

                if (Time.time - _time > list[_ind].m_delaySec)
                {
                    ++_ind;
                    _time = Time.time;
                }

                return list[_ind].m_texture2d;
            }
        }

        private static Dictionary<string, WrapperData> gifTexDict = new Dictionary<string, WrapperData>();

        public static void LoadFromListOf(this MonoBehaviour mono, params GifFile[] gifs)
        {
            if (mono == null)
                throw new ArgumentException("mono");

            if (gifs == null || gifs != null && gifs.Length == 0)
                throw new ArgumentException("gifs");

            foreach (GifFile gif in gifs)
                LoadFrom(mono, gif.path);
        }

        public static WrapperData LoadFromEditor(byte[] array)
        {
            if (array == null)
                throw new ArgumentException("array");

            return InternalCallbackEditor(array);
        }

        //private static IEnumerator LoadFromEditor(string path)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        throw new ArgumentException("path");

        //    if (path.StartsWith("http"))
        //        yield return LoadGifFromUrl(path);
        //    else
        //    {
        //        if (!Path.IsPathRooted(path))
        //        {
        //            TextAsset textAsset = Resources.Load<TextAsset>(path);
        //            string streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, path);

        //            if (textAsset != null)
        //                yield return LoadGifFromResources(path, textAsset.bytes);
        //            else if (File.Exists(streamingAssetsPath))
        //                yield return LoadGifFromFile(streamingAssetsPath);
        //            else
        //                Debug.LogErrorFormat("File '{0}' hasn't been found!", path);
        //        }
        //    }
        //}

        public static void LoadFrom(this MonoBehaviour mono, GifFile gif)
        {
            if (mono == null)
                throw new ArgumentException("mono");

            if (gif == null)
                throw new ArgumentException("gif");

            LoadFrom(mono, gif.path);
        }

        public static void LoadFromListOf(this MonoBehaviour mono, params string[] paths)
        {
            if (mono == null)
                throw new ArgumentException("mono");

            if (paths == null || paths != null && paths.Length == 0)
                throw new ArgumentException("paths");

            foreach (string path in paths)
                LoadFrom(mono, path);
        }

        public static void LoadFrom(this MonoBehaviour mono, string path)
        {
            if (mono == null)
                throw new ArgumentException("mono");

            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("path");

            if (path.StartsWith("http"))
                mono.StartCoroutine(LoadGifFromUrl(path));
            else
            {
                if (!Path.IsPathRooted(path))
                {
                    TextAsset textAsset = Resources.Load<TextAsset>(path);
                    string streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, path);

                    if (textAsset != null)
                        mono.StartCoroutine(LoadGifFromResources(path, textAsset.bytes));
                    else if (File.Exists(streamingAssetsPath))
                        mono.StartCoroutine(LoadGifFromFile(streamingAssetsPath));
                    else
                        Debug.LogErrorFormat("File '{0}' hasn't been found!", path);
                }
                else
                {
                    if (File.Exists(path))
                        mono.StartCoroutine(LoadGifFromFile(path));
                    else
                        Debug.LogErrorFormat("Gif file doesn't exists! Path: {0}", path);
                }
            }
        }

        private static IEnumerator LoadGifFromUrl(string path, WrapperData wrapperData = null)
        {
            using (WWW www = new WWW(path))
            {
                yield return www;

                if (!string.IsNullOrEmpty(www.error))
                    Debug.LogError("File load error.\n" + www.error);
                else
                {
                    gifTexDict.Clear();

                    yield return InternalCallback(www.bytes, wrapperData, path);
                }
            }
        }

        private static IEnumerator LoadGifFromResources(string path, byte[] bytes, WrapperData wrapperData = null)
        {
            yield return InternalCallback(bytes, wrapperData, path);
        }

        private static IEnumerator LoadGifFromFile(string path, WrapperData wrapperData = null)
        {
            byte[] bytes = null;

            yield return Ninja.JumpBack;

            bytes = File.ReadAllBytes(path);

            yield return Ninja.JumpToUnity;

            yield return InternalCallback(bytes, wrapperData, path);
        }

        private static WrapperData InternalCallbackEditor(byte[] bytes)
        {
            WrapperData wrapperData = new WrapperData();

            var num = GetTextureListCoroutine(bytes, (gtList, loop, w, h) =>
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

        private static IEnumerator InternalCallback(byte[] bytes, WrapperData wrapperData, string path)
        {
            if (wrapperData == null)
                wrapperData = new WrapperData();

            yield return GetTextureListCoroutine(bytes, (gtList, loop, w, h) =>
            {
                wrapperData.list = gtList;
                wrapperData.width = w;
                wrapperData.height = h;

                // if (!string.IsNullOrEmpty(path))
                gifTexDict.Add(path, wrapperData);
            },
            wrapperData.filterMode, wrapperData.wrapMode, wrapperData.outputDebugLog);
        }

        //private static void DrawGif(this MonoBehaviour mono, Rect r, Gif gif)
        //{
        //    if (!gifTexDict.ContainsKey(gif.path) && !gif.FlagAsLoaded())
        //        LoadFrom(mono, gif);
        //    else if (gifTexDict.ContainsKey(gif.path))
        //        Draw(r, gifTexDict[gif.path]);
        //}

        //public static void Draw(Rect r, string path)
        //{
        //    Draw(r, gifTexDict.ContainsKey(path) ? gifTexDict[path] : null);
        //}

        private static void Draw(Rect r, WrapperData data)
        {
            if (data == null)
                return;

            if (data != null && data.list != null && data.list.Count > 0)
                GUI.DrawTexture(r, data.NextFrame());
        }
    }
}