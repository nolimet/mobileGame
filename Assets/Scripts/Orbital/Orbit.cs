using UnityEngine;
using System.Collections;
namespace Oribtal
{
    public class Orbit : StellarObject
    {

        public StellarObject parentobj;
        Transform parentPos;
        const float gravitationalConstant = 0.5f;
        // Use this for initialization
        void Start()
        {
            parentPos = transform.parent;
        }

        void FixedUpdate()
        {
            Vector2 diff = parentPos.position - transform.position;
            Vector2 direction = diff.normalized;
            float gravitationalForce = (parentobj.mass * mass * gravitationalConstant) / diff.sqrMagnitude;
            rigidbody2D.AddForce(direction * gravitationalForce);
        }
    }
}