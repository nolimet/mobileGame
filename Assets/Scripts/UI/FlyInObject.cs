using UnityEngine;
using System.Collections;

public class FlyInObject : MonoBehaviour {

    public float WaitForSec = 0f;
    public Vector2 MoveAmount;
    private Vector2 origen;
	// Use this for initialization
	void Start () {
        origen = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (WaitForSec > 0)
        {
            WaitForSec -= Time.deltaTime;
            return;
        }

        Vector2 temp1 = origen + MoveAmount;
        Vector2 temp2 = transform.position;
        Debug.Log(Vector2.Distance(temp2, temp1));
        if (Vector2.Distance(temp2, temp1) > 0.1f)
        {
            Vector2 dir = temp1 - temp2;
            transform.Translate(dir * Time.deltaTime);
        }
        
	}
}
