using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public int Jumpspeed;
   static internal bool Grounded;
    Rigidbody2D mybody;
   public  int direction;
    int counter;
   static internal Animator animator;
   public Vector3 CheckPoint;
      void Start()
    {
         animator = gameObject.GetComponentInChildren<Animator>();  
        counter = 0;
        Grounded = true;
        direction =1 ;
        mybody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
        mybody.gravityScale = 1.1f;
    }

    private void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(mybody.velocity.x));
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
           
            direction = 1;
            mybody.AddForce(Vector2.right * speed * direction);
            mybody.transform.rotation = new Quaternion(0, 0, 0, 0);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            mybody.velocity=new Vector2(0, mybody.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            mybody.AddForce(Vector2.right * speed * direction);
            mybody.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        //if (Input.GetKeyDown(KeyCode.Space) )
        //{
        //    if (Grounded == true)
        //    {
        //        counter=1;
        //        mybody.velocity += Vector2.up * Jumpspeed;
        //    }
        
        //    if (Grounded == false && counter == 1)
        //    {
               
        //        mybody.velocity += Vector2.up * Jumpspeed;
        //        counter=0;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
           
        //    transform.position= new Vector3(transform.position.x + 2 * direction, transform.position.y, transform.position.z);
        //}

        if(Mathf.Abs(mybody.velocity.x)>3)
        { mybody.velocity.Set(3,mybody.velocity.y); }

    
    }
    public void KillPlayer()
    {
        gameObject.transform.position = CheckPoint;
    }
}
