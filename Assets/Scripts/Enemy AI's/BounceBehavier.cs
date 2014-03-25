using UnityEngine;
using System.Collections;

namespace EnemyAI
{
    public class BounceBehavier : Enemybase
    {
        private bool direction = false; //true = left, false = right
        private Animator animator;
        private float deathclock = 1f/24*60;
        public bool kill;

        public override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }
        public override void Update()
        {
            base.Update();
            if (direction)
            {
                if(rigidbody2D.velocity.x<MaxSpeed){
                    rigidbody2D.AddForce(new Vector2(SpeedUp, 0));
                }
            }
            else
            {
                if (rigidbody2D.velocity.x > -MaxSpeed)
                {
                    rigidbody2D.AddForce(new Vector2(-SpeedUp, 0));
                }
            }
            if (kill)
            {
                Kill();
                kill = false;
               
            }
        }

        public void Kill()
        {
            animator.SetBool("Death", true);
            Destroy(this.gameObject, deathclock);
            SpeedUp = 0f;
            rigidbody2D.velocity = Vector2.zero;
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.gameObject.tag == TagManager.enemyTrigger)
            {
                direction = !direction;
                Vector2 tmp = rigidbody2D.velocity;
                tmp.x = 0;
                rigidbody2D.velocity = tmp;
                if (direction)
                {
                    Quaternion tmprot = transform.rotation;
                    tmprot.y = 180;
                    transform.rotation = tmprot;
                }
                else
                {
                    Quaternion tmprot = transform.rotation;
                    tmprot.y = 0;
                    transform.rotation = tmprot;
                }
            }
        }
        public override void OnCollisionEnter2D(Collision2D col)
        {
            base.OnCollisionEnter2D(col);
            if (col.gameObject.tag == TagManager.deadly)
            {
                Kill();
            }
        }
    }
}