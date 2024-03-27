using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Goball", 2);
    }
    void Goball()
    {
        float rand = Random.Range(0,2);
        float randoms = Random.Range(10,50);
        if(rand < 1)
        {
            rb2d.AddForce(new Vector2(randoms, -randoms));
        }
        else
        {
            rb2d.AddForce(new Vector2(-randoms, -randoms));
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        Debug.Log("masok");
        ResetBall();
        Invoke("Goball", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            float counter = 1;

            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y + counter*0.2f;
            rb2d.velocity = vel;
            counter++;
        }
    }
}
