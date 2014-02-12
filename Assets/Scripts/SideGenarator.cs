using UnityEngine;
using System.Collections;

public class SideGenarator : MonoBehaviour {

     public GameObject StartObject;
     public GameObject MidObject;
     public GameObject EndObject;
     public int SizeX;
     public int SizeY;
     public float scale = 1;
     public bool direction;
	// Use this for initialization
	void Start () {
       GameObject temp;
       Vector3 localPos = transform.position;

       temp = Instantiate(StartObject, localPos + new Vector3(0, 0), Quaternion.identity) as GameObject;
       temp.name = "StartSide";
        for(int i = 1 ; i<=SizeX-1;i++)
        {
            temp = Instantiate(MidObject, localPos + new Vector3(i * scale, 0), Quaternion.identity) as GameObject;
            temp.name = "MidSide";
            
        }
        temp = Instantiate(EndObject, localPos + new Vector3(SizeY * scale, SizeX*scale), Quaternion.identity) as GameObject;
        temp.name = "EndSide";
        Destroy(this.gameObject);
	}
}
