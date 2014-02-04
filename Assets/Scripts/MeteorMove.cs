using UnityEngine;
using System.Collections;

public class MeteorMove : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 20f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1.5f * Time.deltaTime, 0, 0);
    }

    void onTriggerEnter2D(Collider2D col)
    {
        if (col.collider.name == "Mouse")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}