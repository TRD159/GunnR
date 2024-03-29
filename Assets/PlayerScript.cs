﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D player, Floor;
    Collision2D floor;

    public float dx = 0;
    public float dy = 0;
    public float maxSpeed;
    public Vector2 position;
    Vector2 forces;
    bool jump = false;
    bool grounded = false;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        position = player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
       
    }
    void FixedUpdate()
    {

        float hori = Input.GetAxis("Horizontal") * 3;
        float vert = 0;
        if(Input.GetAxis("Jump") > 0 && jump)
        {
            vert = Input.GetAxis("Jump") * 5;
            //jump = false;
        }
        //float vert = ((Input.GetAxis("Vertical") < 0) ? 0 : Input.GetAxis("Vertical")) * speed;


        forces = new Vector2(hori, vert);
        

        //forces = new Vector2(hori, vert);
        position = player.transform.position;

        //player.AddForce(new Vector2(hori, vert));

        player.velocity += forces;
        if(player.velocity.x > maxSpeed)
        {
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        }
        if (player.velocity.x < -maxSpeed)
        {
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);
        }

        if(hori == 0)
        {
            if(player.velocity.x > 1)
            {
                player.velocity = new Vector2(player.velocity.x - 1, player.velocity.y);
            } else if(player.velocity.x < -1)
            {
                player.velocity = new Vector2(player.velocity.x + 1, player.velocity.y);
            } else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }
        }

        /*if(player.velocity.magnitude > 5)
        {
            float angle = Mathf.Atan2(player.velocity.y, player.velocity.x);
            player.velocity = new Vector2(5 * Mathf.Cos(angle), 5 * Mathf.Sin(angle));
        }*/
        dx = player.velocity.x;
        dy = player.velocity.y;

        //Debug.Log(dx + ", " + dy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("A");
        jump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jump = false;
    }
}
