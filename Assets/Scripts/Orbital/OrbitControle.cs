using UnityEngine;
using System.Collections;

public class OrbitControle : MonoBehaviour {
    public float forceMultiplyer;

	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");
		Vector3 force = new Vector3();
		if(hor!=0 || ver!=0){
            force = new Vector3(forceMultiplyer * hor, forceMultiplyer * ver);
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
            force.z = forceMultiplyer;
		}

		if(Input.GetKeyDown(KeyCode.LeftControl)){
            force.z = -forceMultiplyer;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody.velocity = new Vector3();
		}

		rigidbody.AddRelativeForce(force);
	}
}
