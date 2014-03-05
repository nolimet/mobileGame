using UnityEngine;
using System.Collections;

public class DarkHole : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
     GameObject boom = Instantiate(Resources.Load<GameObject>("PlasmaExplosion"), col.gameObject.transform.position, col.gameObject.transform.rotation) as GameObject;
     boom.name = "Explosion";
     Destroy(boom, 15f);
    }
}
