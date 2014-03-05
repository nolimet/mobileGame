using UnityEngine;
using System.Collections;

public class SpeedMonitor : MonoBehaviour {

	public GameObject ToMonitor;
	//private GUIText guitext;
	void Start(){

	}

	void Update(){
		guiText.text="VelocityX: " + ToMonitor.rigidbody.velocity.x + "\nVelocityY: " + ToMonitor.rigidbody.velocity.y + "\nVelocityZ: " + ToMonitor.rigidbody.velocity.z;
	}
}
