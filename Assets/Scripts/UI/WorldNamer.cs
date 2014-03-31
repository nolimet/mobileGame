using UnityEngine;
using System.Collections;

public class WorldNamer : MonoBehaviour {

    public int World = 0;
    public int Level = 0;
    public int startingRoom = 0;
	// Use this for initialization
	void Start () {
        name = "World: " + World + " level: " + Level;
	}

}
