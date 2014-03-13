using UnityEngine;
using System.Collections;

public class SpeedMonitor : MonoBehaviour {

	public GameObject ToMonitor;
    public bool is2D= false;
	//private GUIText guitext;
	void Start(){

	}

	void Update(){
        if (!is2D)
        {
            guiText.text = "VelocityX: " + ToMonitor.rigidbody.velocity.x + "\nVelocityY: " + ToMonitor.rigidbody.velocity.y + "\nVelocityZ: " + ToMonitor.rigidbody.velocity.z;
        }
        else
        {
            guiText.text = "VelocityX: " + ToMonitor.rigidbody2D.velocity.x + "\nVelocityY: " + ToMonitor.rigidbody2D.velocity.y;
        }
	}
}
