using UnityEngine;
using System.Collections;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {

        public bool FSXIsMuted = false;
        public bool MusicIsMuted = false;
        public enum playingSound
        {
            idle=0,
            walk=1,
            dead=2,
            jump=3
        };
        public playingSound currentSound = new playingSound();

        void Start()
        {
            this.name = GlobalStatics.audioManager;
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
