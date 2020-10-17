using UnityEngine;

namespace UnityGif.Example.Script
{
    public class UniGifWrapperTest : MonoBehaviour
    {
        public UniGif.GifFile gif;

        public void Start()
        {
            gif.SetMono(this);
        }

        public void Update()
        {
        }

        public void OnGUI()
        {
            if (gif != null)
                gif.Draw(5, 5);
        }
    }
}