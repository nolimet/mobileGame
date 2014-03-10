using UnityEngine;
using System.Collections;

public class moveObjectOnTrigger : MonoBehaviour {

    public Trigger activator;
    private float checkInterval;
    public float addRot;
    private float origen;
    void Start()
    {
        origen = 0;
    }
 
	
	// Update is called once per frame
	void Update () {
        if (activator.Actived)
        {
            /*Quaternion temprot = transform.rotation;
            Vector3 tempcompair = temprot.eulerAngles;
            if (addRot > 0 && tempcompair.z < addRot || addRot < 0 && tempcompair.z >  addRot)
            {
                temprot = Quaternion.Euler(temprot.x, temprot.y, temprot.z + Time.deltaTime);
            }
            transform.rotation = temprot;*/
           // rigidbody2D.AddTorque(200f);
           // rigidbody2D.
            collider2D.enabled = false;
        }
        else if (!activator.Actived)
        {
            /*Quaternion temprot = transform.rotation;
            Vector3 tempcompair = temprot.eulerAngles;
            if (addRot > 0 && tempcompair.z > origen || addRot < 0 && tempcompair.z < origen)
            {
                temprot = Quaternion.Euler(temprot.x, temprot.y, temprot.z - Time.deltaTime);
            }
            transform.rotation = temprot;*/
            collider2D.enabled = true;
        }
	}
}
