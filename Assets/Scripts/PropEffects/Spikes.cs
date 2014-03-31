using UnityEngine;
using System.Collections;
using Player;
namespace PropEffects
{
    public class Spikes : MonoBehaviour
    {

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == TagManager.player)
            {
                PlayerControler player = coll.gameObject.GetComponent<PlayerControler>();
                player.GetHit(999999999);
            }
        }
    }
}
