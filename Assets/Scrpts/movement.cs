using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField] float speed;
    [SerializeField] float power;
    [SerializeField] bool OnGround;
    [SerializeField] bool isDashing, canDash;
    [SerializeField] float dashPower, dashCoolDown, dashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && OnGround == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sp.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && OnGround == true)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sp.flipX = false;
        }
        else if (OnGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.99f, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && OnGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, power);
            OnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine("Dash");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("obstacle") || other.gameObject.CompareTag("hit"))
        {
            OnGround = true;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(rb.velocity.x * dashPower, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
