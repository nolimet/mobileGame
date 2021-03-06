﻿using UnityEngine;
using System.Collections;
namespace PropEffects
{
    public class PickupScript : MonoBehaviour
    {
        public bool changeRoom;
        public int NextRoom;
        private bool loadNextRoom;
        private bool loading = false;
        private Vector2 origen;
        private float wait = 1F;
        // Use this for initialization
        void Start()
        {
            origen = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 temp;
            temp = origen;
            temp.y += Mathf.PingPong(Time.time / 2, 0.5f) - 0.25f;
            transform.position = temp;

            if (loadNextRoom && !loading)
            {
                wait -= Time.deltaTime;
                if (wait < 0)
                {
                    GlobalStatics.load(NextRoom);
                    loading = true;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == TagManager.player)
            {
                Debug.Log("hitplayer");
                if (changeRoom)
                {
                    loadNextRoom = true;

                }
                else
                {
                    Destroy(this.gameObject, 0.5f);
                }
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == TagManager.player)
            {
                Debug.Log("hitplayer");
                if (changeRoom)
                {
                    loadNextRoom = true;
                }
                else
                {
                    Destroy(this.gameObject, 0.5f);
                }
            }
        }
    }
}