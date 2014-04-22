using UnityEngine;
using System.Collections;

namespace Player
{
    public class AudioControler : MonoBehaviour
    {

        private Managers.AudioManager AudioManager;
        public Player.PlayerControler parentControler;
        public soundPlayer walkSound;
        public soundPlayer jumpSound;
        public soundPlayer idleSound;
        public soundPlayer dieSound;
        public AudioClip graviSwitch;

        private bool[] soundStates = new bool[4]; //0 - idle, 1 walk,2 dead, 3 jump
        // Use this for initialization
        void Start()
        {
            Destroy(walkSound.gameObject);
            Destroy(jumpSound.gameObject);
            Destroy(idleSound.gameObject);
            Destroy(dieSound.gameObject);
            Destroy(this);
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                if (go.name == GlobalStatics.audioManager)
                {
                    AudioManager = go.GetComponent<Managers.AudioManager>();
                }
            }
            if (AudioManager == null)
            {
                Destroy(this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!AudioManager.FSXIsMuted)
            {
                if (!soundStates[1])
                {
                    //walkingSound;
                    if (parentControler.RightButton.state || parentControler.LeftButton.state)
                    {
                        Stopall();
                        walkSound.Play();
                        soundStates[1] = true;
                        AudioManager.currentSound = Managers.AudioManager.playingSound.walk;
                    }
                    else if (parentControler.rigidbody2D.velocity.x == 0f && parentControler.rigidbody2D.velocity.y == 0f)
                    {
                        Stopall();
                        walkSound.Play();
                        AudioManager.currentSound = Managers.AudioManager.playingSound.walk;
                    }
                }
                if (!soundStates[3])
                {
                    //jumpSound
                    if (parentControler.rigidbody2D.velocity.y > 0f && parentControler.rigidbody2D.velocity.y < 1.3f)
                    {
                        Stopall();
                        jumpSound.Play();
                        soundStates[3] = true;
                        AudioManager.currentSound = Managers.AudioManager.playingSound.walk;
                    }
                }
                //deathSound
                if (!soundStates[2])
                {
                    if (parentControler.transform.position.y < parentControler.deathHeight)
                    {
                        Stopall();
                        dieSound.Play();
                        soundStates[2] = true;
                        AudioManager.currentSound = Managers.AudioManager.playingSound.dead;
                    }
                }
                //Idle sound;
                if (!soundStates[0])
                {
                    if (parentControler.rigidbody2D.velocity == Vector2.zero)
                    {
                        Stopall();
                        idleSound.Play();
                        soundStates[0] = true;
                        AudioManager.currentSound = Managers.AudioManager.playingSound.idle;
                    }
                }
            }
        }

        void playSound(AudioClip sound)
        {
            audio.PlayOneShot(sound);

        }
        void GraviSwitch()
        {
            audio.PlayOneShot(graviSwitch);
        }

        void Stopall()
        {
            walkSound.Stop();
            jumpSound.Stop();
            idleSound.Stop();
            dieSound.Stop();
            int l = soundStates.Length;
            for (int i = 0; i > l; i++)
            {
                soundStates[i] = false;
            }
        }
    }
}