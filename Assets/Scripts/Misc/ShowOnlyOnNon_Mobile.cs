using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    class ShowOnlyOnNon_Mobile : MonoBehaviour
    {
        void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
