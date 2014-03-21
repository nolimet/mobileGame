using UnityEngine;
using System.Collections;
namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {

        public GameObject Head;
        public GameObject Ear;
        public AnimationGroup HindeLeg;
        public AnimationGroup Leg;
        public GameObject MainBody;


        public bool Idle = true;


        // Use this for initialization
        void Start()
        {
            if (HindeLeg.Part.Length != 3)
            {
                Debug.LogError("HindeLeg Needs 3 parts to work correctly!");
            }
            if (Leg.Part.Length != 3)
            {
                Debug.LogError("Leg Needs 3 parts to work correctly!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Idle)
            {
                Quaternion HeadRot = Head.transform.rotation;
                HeadRot.z = Mathf.PingPong(Time.time / 8, 0.2f);
                Head.transform.rotation = HeadRot;

                Quaternion EarRot = Ear.transform.rotation;
                EarRot.z = Mathf.PingPong(Time.time / 16, 0.1f);
                Ear.transform.rotation = EarRot;
            }

        }
    }
}
