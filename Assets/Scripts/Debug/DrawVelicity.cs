using UnityEngine;
using System.Collections;
namespace debug
{
    public class DrawVelicity : MonoBehaviour
    {

        public bool use2D = false;
        public float scaling = 5f;
        public float fadeTime = 0.01f;
        public Color Colour = Color.blue;

        // Update is called once per frame
        void Update()
        {
            if (use2D)
            {
                Debug.DrawLine(transform.position, new Vector3(rigidbody2D.velocity.x / scaling, rigidbody2D.velocity.y / scaling, 0) + transform.position, Colour, fadeTime);
            }
            else
            {
                Debug.DrawLine(transform.position, rigidbody.velocity / scaling + transform.position, Colour, fadeTime);
            }
        }
    }
} 
