using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUP = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    // public KeyCode moveLeft = KeyCode.A;
    // public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    public float BoundY = 3.0f;
    private Rigidbody2D rb2d;
    public Animator attack;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vel = rb2d.velocity;
        if(Input.GetKey(moveUP))
        {
            vel.y = speed;
        }
        else if(Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        // if(Input.GetKey(moveLeft))
        // {
        //     vel.x = -speed;
        // }
        // else if(Input.GetKey(moveRight))
        // {
        //     vel.x = speed;
        // }
        // else
        // {
        //     vel.x = 0;
        // }

        rb2d.velocity = vel;

        var pos = transform.position;
        if(pos.y > BoundY)
        {
            pos.y = BoundY;
        }
        else if(pos.y < -BoundY)
        {
            pos.y = -BoundY;
        }
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Ball"))
        {
            attack.SetTrigger("Tabrak");
        }
    }
}
