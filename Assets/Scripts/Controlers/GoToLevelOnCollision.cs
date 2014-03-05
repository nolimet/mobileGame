using UnityEngine;
using System.Collections;

public class GoToLevelOnCollision : MonoBehaviour {

    public int Togoto = 0;

    void onCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == TagManager.player)
        {
            GlobalStatics.load(Togoto);
        }
    }

    void onTriggerEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == TagManager.player)
        {
            GlobalStatics.load(Togoto);
        }
    }
}
