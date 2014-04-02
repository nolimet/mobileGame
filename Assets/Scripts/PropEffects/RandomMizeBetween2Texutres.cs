using UnityEngine;
using System.Collections;
namespace PropEffects
{
    public class RandomMizeBetween2Texutres : MonoBehaviour
    {
        [Range(0,100f)]
        public float chance;

        public Sprite[] Sprites;
        // Use this for initialization
        void Start()
        {
            float resizesChanse = chance / 100f;
            if (Random.value > resizesChanse)
            {
                SpriteRenderer spriterendere = GetComponent<SpriteRenderer>();
                int RandomIndex1 = Mathf.FloorToInt(Random.Range(0f, Sprites.Length));
                spriterendere.sprite = Sprites[RandomIndex1];
            }
            Destroy(this);
        }
    }
}