using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public Transform[] Targets;
	public KeyCode SwitchCamPos;
	public float MoveTime = 1f;
	public float speed = 1f;
	public float accurcy = 0.1f;
	private bool paused;
	
	void OnPauseGame ()
	{
		paused = true;
	}
	
	void OnResumeGame ()
	{
		paused = false;
	}

	// Update is called once per frame
	void Update () {
		if(!paused){
			if(Targets.Length>0){
				if(Input.GetKeyDown(SwitchCamPos)){
					GlobalStatics.currentChar++;
						if(GlobalStatics.currentChar>=Targets.Length){
						GlobalStatics.currentChar=0;
					}
				}

				Vector3 temp = Targets[GlobalStatics.currentChar].position;
				temp.z = transform.position.z;

				if(Vector3.Distance(transform.position,temp)>=accurcy){
					Vector3 dir = Targets[GlobalStatics.currentChar].position - transform.position;
					dir.z=0;
					transform.Translate(dir*speed*Time.deltaTime);
					Debug.DrawLine(transform.position,temp,Color.green);

				}
			}
		}
	}
}
