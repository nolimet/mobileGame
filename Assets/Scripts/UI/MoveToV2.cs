using UnityEngine;
using System.Collections;

namespace menu
{
    public class MoveToV2 : MonoBehaviour
    {
        public int menuID;
        private Vector2 origen;
        public Vector2 moveAmount;
        public bool move; //true it goes to new pos. False it goes to origen
        // Use this for initialization
        void Start()
        {
            origen = transform.position;
            if (move)
            {
                origen -= moveAmount;
            }
            Debug.Log(origen);
        }

        // Update is called once per frame
        void Update()
        {
            if (move)
            {
                Vector2 temp1 = origen + moveAmount;
                Vector2 temp2 = transform.position;
                if (Vector2.Distance(temp2, temp1) > 0.1f)
                {
                    Vector2 dir = temp1 - temp2;
                    transform.Translate(dir * Time.deltaTime);
                }
            }
            else
            {
                Vector2 temp1 = origen;
                Vector2 temp2 = transform.position;
                if (Vector2.Distance(temp2, temp1) > 0.1f)
                {
                    Vector2 dir = temp1 - temp2;
                    transform.Translate(dir * Time.deltaTime);
                }
            }
        }

    }
}
