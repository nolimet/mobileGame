using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == TagManager.player)
        {
            BetaCharControler player = coll.gameObject.GetComponent<BetaCharControler>();
            player.GetHit(999999999);
        }
    }
}
