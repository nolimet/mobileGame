using UnityEngine;
using System.Collections;

public class InIT : MonoBehaviour {

    private SpriteRenderer SPRender;
    private float Alpha;
    public float timeScale;
    private float startime;

    void Start()
    {
        SPRender = GetComponent<SpriteRenderer>();
        startime = Time.time;
    }

    void Update()
    {
       // timeLength -= Time.deltaTime;
        //Alpha = Mathf.FloorToInt((255f/timeMax)* timeLength);
       // Alpha = Mathf.PingPong(Time.time*2, 255);
        SPRender.color = new Color(1,1,1,Mathf.PingPong((Time.time / timeScale)-startime, 1));
    }
}
