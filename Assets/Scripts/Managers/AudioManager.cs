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
            int tempSXF = PlayerPrefs.GetInt("FSXIsMuted");
            if (tempSXF == 1)
            {
                FSXIsMuted = true;
            }
            int tempMusic = PlayerPrefs.GetInt("MusicIsMuted");
            if (tempSXF == 1)
            {
                MusicIsMuted = true;
            }
        }

        public void ToggleMusic()
        {
            MusicIsMuted = !MusicIsMuted;
            if (MusicIsMuted)
            {
                PlayerPrefs.SetInt("FSXIsMuted", 1);
            }
            else
            {
                PlayerPrefs.SetInt("FSXIsMuted", 0);
            }
        }

        public void ToggleFSX()
        {
            FSXIsMuted = !FSXIsMuted;
            if (MusicIsMuted)
            {
                PlayerPrefs.SetInt("MusicIsMuted", 1);
            }
            else
            {
                PlayerPrefs.SetInt("MusicIsMuted", 0);
            }
        }
        void OnApplicationExit()
        {
            PlayerPrefs.Save();
        }
    }
}
