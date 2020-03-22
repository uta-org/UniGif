using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CielaSpike;
using UnityEngine;
using UnityEngine.Networking;
using uzLib.Lite.ExternalCode.Extensions;

#if !(!UNITY_2020 && !UNITY_2019 && !UNITY_2018 && !UNITY_2017 && !UNITY_5)
using uzLib.Lite.Extensions;
using RectHelper = uzLib.Lite.ExternalCode.Extensions.RectHelper;
#endif

namespace UnityGif
{
    public static partial class UniGif
    {
        private static readonly Dictionary<string, WrapperData> gifTexDict = new Dictionary<string, WrapperData>();

        [Obsolete]
        public static void LoadFromListOf(this MonoBehaviour mono, params GifFile[] gifs)
        {
            if (mono == null) throw new ArgumentException("mono");

            if (gifs == null || gifs != null && gifs.Length == 0) throw new ArgumentException("gifs");

            foreach (var gif in gifs) LoadFrom(mono, gif.path);
        }

        [Obsolete]
        public static void LoadFrom(this MonoBehaviour mono, GifFile gif)
        {
            if (mono == null) throw new ArgumentException("mono");

            if (gif == null) throw new ArgumentException("gif");

            LoadFrom(mono, gif.path);
        }

        [Obsolete]
        public static void LoadFromListOf(this MonoBehaviour mono, params string[] paths)
        {
            if (mono == null) throw new ArgumentException("mono");

            if (paths == null || paths != null && paths.Length == 0) throw new ArgumentException("paths");

            foreach (var path in paths) LoadFrom(mono, path);
        }

        public static void LoadFrom(this MonoBehaviour mono, string path)
        {
            if (mono == null) throw new ArgumentException("mono");

            if (string.IsNullOrEmpty(path)) throw new ArgumentException("path");

            if (path.StartsWith("http"))
            {
                mono.StartCoroutineAsync(LoadGifFromUrl(path, mono));
            }
            else
            {
                if (!Path.IsPathRooted(path))
                {
                    var textAsset = Resources.Load<TextAsset>(path);
                    var streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, path);

                    if (textAsset != null)
                        mono.StartCoroutine(LoadGifFromResources(path, textAsset.bytes, mono));
                    else if (File.Exists(streamingAssetsPath))
                        mono.StartCoroutine(LoadGifFromFile(streamingAssetsPath, mono));
                    else
                        Debug.LogErrorFormat("File '{0}' hasn't been found!", path);
                }
                else
                {
                    if (File.Exists(path))
                        mono.StartCoroutine(LoadGifFromFile(path, mono));
                    else
                        Debug.LogErrorFormat("Gif file doesn't exists! Path: {0}", path);
                }
            }
        }

        private static IEnumerator LoadGifFromUrl(string path, MonoBehaviour mono, WrapperData wrapperData = null)
        {
            using (var request = UnityWebRequest.Get(path))
            {
                yield return request.SendWebRequest();

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError("File load error.\n" + request.error);
                }
                else
                {
                    gifTexDict.Clear();

                    var textureData = ((DownloadHandlerTexture)request.downloadHandler).data;
                    yield return InternalCallback(textureData, wrapperData, path, mono);
                }
            }
        }

        private static IEnumerator LoadGifFromResources(string path, byte[] bytes, MonoBehaviour mono,
            WrapperData wrapperData = null)
        {
            yield return InternalCallback(bytes, wrapperData, path, mono);
        }

        private static IEnumerator LoadGifFromFile(string path, MonoBehaviour mono, WrapperData wrapperData = null)
        {
            byte[] bytes = null;

            yield return Ninja.JumpBack;
            bytes = File.ReadAllBytes(path);
            yield return Ninja.JumpToUnity;

            yield return InternalCallback(bytes, wrapperData, path, mono);
        }

        private static IEnumerator InternalCallback(byte[] bytes, WrapperData wrapperData, string path,
            MonoBehaviour mono)
        {
            if (wrapperData == null)
            {
                var name = Path.GetFileNameWithoutExtension(path);
                wrapperData = new WrapperData { name = name };
            }

            yield return GetTextureListCoroutine(bytes, (gtList, loop, w, h) =>
                {
                    wrapperData.list = gtList;
                    wrapperData.width = w;
                    wrapperData.height = h;

                    gifTexDict.Add(path, wrapperData);
                },
                mono, null, wrapperData.filterMode, wrapperData.wrapMode, wrapperData.outputDebugLog);
        }

        private static bool Draw(Rect r, WrapperData data)
        {
            if (data == null)
                // Debug.LogError("Gif data is null!");
                return false;

            if (data?.list != null && data.list.Count > 0) GUI.DrawTexture(r, data.NextFrame());

            return true;
        }

        [Serializable]
        public class GifFile
        {
            private object m_editorInstance;

            [SerializeField] private MonoBehaviour mono;

            [SerializeField] internal string path;

            public GifFile(MonoBehaviour mono)
            {
                this.mono = mono ? mono : throw new ArgumentNullException(nameof(mono));
            }

            public GifFile(string name, MonoBehaviour mono, byte[] array)
                : this(mono)
            {
                _LoadFrom(name, array, null);
            }

            public GifFile(string name, MonoBehaviour mono, byte[] array, object editorInstance)
                : this(mono)
            {
                //Debug.Log($"Creating instance with name '{name}'");

                m_editorInstance = editorInstance;
                _LoadFrom(name, array, null);
            }

            public WrapperData Data { get; private set; }

            public bool IsReady => Data?.IsReady == true;

            public bool IsInitialized => !IsInitFlag && !IsReady;

            //private bool m_isInit;
            //public bool IsInitFlag { get { return m_isInit; } private set { m_isInit = value; Debug.Log("Setting init flag! (Check stacktrace)"); } }
            // Fixed note: Do as non-auto property, to avoid errors
            // Debug.Log("Setting init flag! (Check stacktrace)");

            public bool IsInitFlag { get; private set; }

            public void Draw(int xMin, int yMin)
            {
                if (!IsReady)
                    return;

                Draw(new Rect(xMin, yMin, Data.width, Data.height));
            }

            public void InitOnce(string name, MonoBehaviour mono, object editorInstance)
            {
                if (IsInitFlag)
                    return;

                if (!IsInitFlag)
                    IsInitFlag = true;

                Init(name, mono, editorInstance);
            }

            public void InitIfNeededOnce(string name, MonoBehaviour mono, object editorInstance)
            {
                // ThreadedDebug.Log($"Is Init Flag?: {IsInitFlag}");

                if (!IsInitFlag)
                {
                    IsInitFlag = true;
                    InitIfNeeded(name, mono, editorInstance);
                }
            }

            public void InitIfNeeded(string name, MonoBehaviour mono, object editorInstance)
            {
                if (!IsInitFlag) IsInitFlag = true;

                if (IsInitialized)
                {
                    Debug.LogError("Gif was already initialized!");
                    return;
                }

                Init(name, mono, editorInstance);
            }

            public void Init(string name, MonoBehaviour mono, object editorInstance)
            {
                if (!IsInitFlag)
                    IsInitFlag = true;

                if (this.mono == null)
                    this.mono = mono;

                if (m_editorInstance == null)
                    m_editorInstance = editorInstance;

                // Debug.Log($"Initializing from path {path} || Is Already Ready?: {IsReady}");
                _LoadFrom(name, File.ReadAllBytes(path), null);
            }

            public void Draw()
            {
                if (!IsReady)
                    return;

                Draw(new Rect(0, 0, Data.width, Data.height));
            }

            public bool Draw(Rect rect)
            {
                return UniGif.Draw(rect, Data);
            }

            private void _LoadFrom(string name, byte[] array, Action callback)
            {
                if (array.IsNullOrEmpty())
                    throw new ArgumentNullException(nameof(array));

                // Debug.Log($"Loading gif with name {name}!");

                // Note: This is used within the editor
                Data = null;

                try
                {
                    void Finish(WrapperData wrapperData)
                    {
                        // ThreadedDebug.Log($"Loaded gif! (Is List null?: {wrapperData.list?.IsNullOrEmpty()})");

                        Data = wrapperData;
                        callback?.Invoke();
                    }

                    //Action<WrapperData> Finish = (wrapperData) =>
                    //{
                    //    ThreadedDebug.Log($"Loaded gif! (Is List null?: {wrapperData.list?.IsNullOrEmpty()})");

                    //    Data = wrapperData;
                    //    callback?.Invoke();
                    //};

                    MainRoutine(name, array, m_editorInstance, Finish).StartSmartCorotine(m_editorInstance, mono);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    throw;
                }
            }

            public void UpdateFromPath(string path, Action callback)
            {
                // Note: This can cause confusion
                var name = Path.GetFileNameWithoutExtension(path);

                _LoadFrom(name, File.ReadAllBytes(path), callback);
            }

            public void UpdateFromPath(string path, object thisRef)
            {
                m_editorInstance = thisRef;
                UpdateFromPath(path, null);
            }

            public void UpdateFromPath(string path, Action callback, object thisRef)
            {
                var name = Path.GetFileNameWithoutExtension(path);

                m_editorInstance = thisRef;
                _LoadFrom(name, File.ReadAllBytes(path), callback);
            }

            // Note: Used only on Editor
            public void Draw(RectHelper wrapper, float maxWidth = 200)
            {
                if (Data == null)
                    return;

                var v = RedimGif(Data, maxWidth);

                var r = wrapper.NextHeight(v.y);

                // Set the rect dimensions
                r.y -= v.y;
                r.x += (Screen.width - maxWidth) / 2;
                r.width = v.x;

                Draw(r, maxWidth);
            }

            public void Draw(Rect r, float maxWidth = 200)
            {
                if (Data != null)
                    // Draw gif with the desired dimensions
                    _Draw(r, Data);
                else
                    Debug.LogWarning("Something unexpected happened!");
            }

            private void _Draw(Rect r, WrapperData data)
            {
                if (!IsReady) return;

                if (data?.list != null && data.list.Count > 0) GUI.DrawTexture(r, data.NextFrame());
            }

            private static Vector2 RedimGif(WrapperData data, float maxWidth)
            {
                if (data.IsNull())
                    throw new ArgumentNullException(nameof(data));

                return new Vector2(maxWidth, data.height * (maxWidth / data.width));
            }

            private IEnumerator MainRoutine(string name, byte[] bytes, object thisReference,
                Action<WrapperData> callback)
            {
                if (callback == null)
                    throw new ArgumentNullException(nameof(callback));

                var wrapperData = new WrapperData { name = name };

                yield return GetTextureListCoroutine(bytes, (gtList, loop, w, h) =>
                    {
                        // ThreadedDebug.Log($"Is null?: {gtList.IsNullOrEmpty()}");

                        wrapperData.list = gtList;
                        wrapperData.width = w;
                        wrapperData.height = h;
                    }, thisReference, mono, wrapperData.filterMode, wrapperData.wrapMode, wrapperData.outputDebugLog)
                    .CreateSmartCorotine(thisReference, mono);

                callback(wrapperData);
            }

            public Texture2D GetFirstFrame()
            {
                return Data?.list?.FirstOrDefault()?.m_texture2d;
            }
        }

        [Serializable]
        public class WrapperData
        {
            private int _ind;
            private float _time;

            public FilterMode filterMode = FilterMode.Point;
            public List<GifTexture> list;

            //private string _name;

            //public string name
            //{
            //    get => _name;
            //    set { _name = value; Debug.Log(_name); }
            //}

            public string name;
            public bool outputDebugLog;

            public int width, height, loop;
            public TextureWrapMode wrapMode = TextureWrapMode.Clamp;

            private WrapperData()
            {
            }

            public WrapperData(FilterMode filterMode = FilterMode.Point,
                TextureWrapMode wrapMode = TextureWrapMode.Clamp, bool outputDebugLog = false)
            {
                this.filterMode = filterMode;
                this.wrapMode = wrapMode;
                this.outputDebugLog = outputDebugLog;
            }

            //public WrapperData(List<GifTexture> list, int width, int height, int loop = 0)
            //{
            //    this.list = list;
            //    this.width = width;
            //    this.height = height;
            //    this.loop = loop;
            //}

            public bool IsReady => !list.IsNullOrEmpty();

            public Texture2D NextFrame()
            {
                if (_ind == list.Count - 1) _ind = 0;

                // Fixed: realtimeSinceStartup must be used, because of the Editor ('Time.time' sometimes get bugged)
                if (Time.realtimeSinceStartup - _time > list[_ind].m_delaySec)
                {
                    ++_ind;
                    _time = Time.realtimeSinceStartup;
                }

                return list[_ind].m_texture2d;
            }

            public bool IsNull()
            {
                return list.IsNullOrEmpty();
            }

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Name: {name}");
                sb.AppendLine($"List Count: {list.PrintListLength()}");
                sb.AppendLine($"Width: {width}");
                sb.AppendLine($"Height: {height}");
                sb.AppendLine($"Loop: {loop}");
                sb.AppendLine($"Filter Mode: {filterMode}");
                sb.AppendLine($"Wrap Mode: {wrapMode}");
                sb.AppendLine($"Output Debug: {outputDebugLog}");

                return sb.ToString();
            }
        }
    }
}