using UnityEngine;
using System.Collections;

public class MeteorMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1.5f * Time.deltaTime, 0, 0);
        Destroy(gameObject, 10f);
    }

    void onTriggerEnter2D(Collider2D col)
    {
        if (col.collider.name == "Mouse")
        {
            Application.LoadLevel(0);
        }
    }
}