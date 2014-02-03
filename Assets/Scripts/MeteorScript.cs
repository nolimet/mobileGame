using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour
{
    public GameObject meteor;
    public float spawnTimer = 4f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0)
        {
            int random = Random.Range(-4, 2);
            Vector3 positions = new Vector3(transform.position.x + 10, random, 0f);

            GameObject clone;

            clone = Instantiate(meteor, positions, transform.rotation) as GameObject;
           // clone.transform.position.z = 0;
            spawnTimer = 4f;
        }
    }
}