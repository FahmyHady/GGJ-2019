using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsAnimation : MonoBehaviour
{
   public float x;
   public float y;
    Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        player = collision.gameObject.GetComponent<Rigidbody2D>();
        player.velocity = Vector2.zero;
        PlayerControl.canMove = false;
        PlayerControl.animator.Play("Walking");
        player.AddForce(Vector2.right*x);
        StartCoroutine(JumpDown());
    }

    IEnumerator JumpDown()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerControl.animator.Play("GoDown");
        yield return new WaitForSeconds(0.5f);
        player.AddForce(new Vector2(x, y));
        yield return new WaitForSeconds(1);
        PlayerControl.canMove = true;

    }
}
