using UnityEngine;
using System.Collections;

namespace EnemyAI
{
    public class Enemybase : MonoBehaviour
    {
        public float SpeedUp = 0.1f;
        public float MaxSpeed = 2f;


        virtual public void Start()
        {

        }

        virtual public void Update()
        {

        }

        virtual public void OnTriggerEnter2D(Collider2D other)
        {

        }

        virtual public void OnCollisionEnter2D(Collision2D col)
        {

        }
    }
}