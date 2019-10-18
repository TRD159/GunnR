using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D player, Floor;
    Collision2D floor;

    public float dx = 0;
    public float dy = 0;
    public float x;
    public float y;
    bool jump = true;
    bool grounded = false;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
       
    }
    void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal") * speed;
        float vert = Input.GetAxis("Vertical") * speed; ;
        x = transform.position.x;
        y = transform.position.y;
        //player.AddForce(new Vector2(hori, vert));
        
        player.velocity = new Vector2(player.velocity.x + hori, player.velocity.y + vert);
        if(player.velocity.magnitude > 15)
        {
            float angle = Mathf.Atan2(player.velocity.y, player.velocity.x);
            player.velocity = new Vector2(15 * Mathf.Cos(angle), 15 * Mathf.Sin(angle));
        }
        dx = player.velocity.x;
        dy = player.velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A");
    }
}
