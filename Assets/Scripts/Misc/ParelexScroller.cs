using UnityEngine;
using System.Collections;

public class ParelexScroller : MonoBehaviour {

    public float scrollSpeed;
    [Range (1,0)]
    public float Scaling;
    private Player.PlayerControler player;
    public Transform[] Layers;
    private bool NoLayars;
    void Start()
    {
        player = GetComponent<Player.PlayerControler>();
        if (Layers.Length == 0)
        {
            NoLayars = true;
        }
    }
    void Update()
    {
        if (NoLayars)
        {
            float x = player.rigidbody2D.velocity.x;
            if (x != 0)
            {
                for (int i = 0; i < Layers.Length; i++)
                {
                    //Debug.Log(i);
                    Vector2 move = new Vector3(scrollSpeed * x / 30 / (0.2f * (1 + i)), 0f, 0f);
                    Layers[i].Translate(move);
                }
            }
        }
    }
}
