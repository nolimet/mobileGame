﻿using UnityEngine;
using System.Collections;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {

        public Transform Target;
        public float MoveTime = 1f;
        public float speed = 1f;
        public float accurcy = 0.1f;
        public bool lockXAxis = false;
        private bool paused;

        void Start()
        {
            if (Target == null)
            {
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in objects)
                {
                    if (go.tag == TagManager.player)
                    {
                        Target = go.GetComponent<Transform>();
                    }
                }
            }

            Vector3 temp = Target.position;
            temp = Target.transform.position;
            temp.z = transform.position.z;
            transform.position = temp;

        }
        void OnPauseGame()
        {
            paused = true;
        }

        void OnResumeGame()
        {
            paused = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!paused)
            {
                Vector3 temp = Target.position;
                temp.z = transform.position.z;

                if (Vector3.Distance(transform.position, temp) >= accurcy)
                {
                    Vector3 dir = Target.position - transform.position;
                    dir.z = 0;
                    if (lockXAxis)
                    {
                        dir.x = 0;
                    }
                    transform.Translate(dir * speed * Time.deltaTime);
                    Debug.DrawLine(transform.position, temp, Color.green);
                }
            }
        }
    }
}