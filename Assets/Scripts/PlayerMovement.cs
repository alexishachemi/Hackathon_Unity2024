using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 direction;
    public Camera cam;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            cam.enabled = false;
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("speed", direction.sqrMagnitude);
        if (direction.x < -0.01) 
        {
            anim.SetBool("facingLeft", true);
        } else if (direction.x > 0.01)
        {
            anim.SetBool("facingLeft", false);
        }
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
