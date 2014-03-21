using UnityEngine;
using System.Collections;
namespace PropEffects
{
    public class RandomMizeBetween2Texutres : MonoBehaviour
    {

        public Sprite[] Sprites;
        // Use this for initialization
        void Start()
        {
            SpriteRenderer spriterendere = GetComponent<SpriteRenderer>();
            double randomval = (Mathf.Floor(Random.Range(0f, Sprites.Length)));
            int RandomIndex = (int)randomval;
            spriterendere.sprite = Sprites[RandomIndex];
        }
    }
}