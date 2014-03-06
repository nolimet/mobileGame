using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    public bool Actived = false;
    public bool OntimeShot = true;

	// Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.player)
        {
            Actived = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.player)
        {
            if (!OntimeShot)
            {
                Actived = false;
            }
        }
    }
}
