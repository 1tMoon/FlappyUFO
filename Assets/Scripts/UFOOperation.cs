using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOOperation : MonoBehaviour
{
    public Rigidbody2D rigidbodyUFO;
    public Animator anim;

    private bool move = false;
    private bool die = false;

    public float force = 200f;
    // Start is called before the first frame update
    void Start()
    {
        this.Idle();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.die)
            return;
        if (move == true && Input.GetMouseButtonDown(0))
        {
            rigidbodyUFO.velocity = Vector2.zero;
            rigidbodyUFO.AddForce(new Vector2(0, force), ForceMode2D.Force);
        }
    }

    public void Move()
    {
        this.move = true;
    }

    public void Idle()
    {
        this.rigidbodyUFO.Sleep();
        this.anim.SetTrigger("Idle");
    }
    public void Jump()
    {
        this.rigidbodyUFO.WakeUp();
        this.anim.SetTrigger("Jump");
    }
    public void Man()
    {
        this.die = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        this.Man();
    }
}
