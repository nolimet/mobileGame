using UnityEngine;
using System.Collections;
namespace menu
{
    public class SlowRotate : MonoBehaviour
    {

        public float Speed = 0.1f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
        }
    }
}