using UnityEngine;
using System.Collections;

public class MoveToV2 : MonoBehaviour {

    public TriggerV2[] Triggers;
    private Vector2 origen;
    public Vector2 moveAmount;
    public bool move; //true it goes to new pos. False it goes to origen
	// Use this for initialization
	void Start () {
        if (Triggers.Length == 0)
        {
            Debug.LogError("NO TIGGERS IN Triggers");
        }
        origen = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        int l = Triggers.Length;
        for (int i = 0; i < l; i++)
        {
            if (Triggers[i].State)
            {
                //Triggers[i].State = false;
                Triggers[i].triggered = true;
                move = !move;

            }
        }

        if (move)
        {
            Vector2 temp1 = origen + moveAmount;
            Vector2 temp2 = transform.position;
            // Debug.Log(Vector2.Distance(temp2, temp1));
            if (Vector2.Distance(temp2, temp1) > 0.1f)
            {
                Vector2 dir = temp1 - temp2;
                transform.Translate(dir * Time.deltaTime);
            }
        }
        else
        {
            Vector2 temp1 = origen;
            Vector2 temp2 = transform.position;
            // Debug.Log(Vector2.Distance(temp2, temp1));
            if (Vector2.Distance(temp2, temp1) > 0.1f)
            {
                Vector2 dir = temp1 - temp2;
                transform.Translate(dir * Time.deltaTime);
            }
        }
	}

}
