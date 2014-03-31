using UnityEngine;
using System.Collections;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {

        public bool FSXIsMuted = false;
        public bool MusicIsMuted = false;

        void Start()
        {
            this.name = "AudioManager";
            Object.DontDestroyOnLoad(this.gameObject);
        }

        public void ToggleMusic()
        {
            MusicIsMuted = !MusicIsMuted;
        }

        public void ToggleFSX()
        {
            FSXIsMuted = !FSXIsMuted;
        }
    }
}
