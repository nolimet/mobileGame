using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    void OnCollisionEnter2D(Collider2D coll)
    {
        if (coll.tag == TagManager.player)
        {
            BetaCharControler player = coll.gameObject.GetComponent<BetaCharControler>();
            
        }
    }
}
