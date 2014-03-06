using UnityEngine;
using System.Collections;

public class moveObjectOnTrigger : MonoBehaviour {

    public Trigger activator;
    private bool atNewLocation=false;
    private float checkInterval;
    public float addRot;
    private float origen;
    void Start()
    {
        origen = transform.rotation.z;
    }
 
	
	// Update is called once per frame
	void Update () {
        if (activator.Actived&&!atNewLocation)
        {
            Quaternion temprot = transform.rotation;
            if (addRot > 0 && temprot.z<=origen+addRot || addRot<0 && temprot.z>=origen+addRot)
            {
                temprot.z += addRot * (Time.deltaTime*2);
            }
            transform.rotation = temprot;
        }
        else if (!activator.Actived)
        {
            Quaternion temprot = transform.rotation;
            if (addRot > 0 && temprot.z >= origen || addRot < 0 && temprot.z <= origen)
            {
                temprot.z -= addRot * (Time.deltaTime * 2);
            }
            transform.rotation = temprot;
        }

        if (checkInterval <= 0)
        {
            atNewLocation = false;
            checkInterval = 0.2f;
        }
        checkInterval -= Time.deltaTime;
	}
}
