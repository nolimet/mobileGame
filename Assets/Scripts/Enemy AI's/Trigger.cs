using UnityEngine;
using System.Collections;

namespace EnemyAI
{
    public class Trigger : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            name = "EnemyTrigger";
        }
    }
}
