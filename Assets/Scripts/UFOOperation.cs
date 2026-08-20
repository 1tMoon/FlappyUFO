using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UFOOperation : MonoBehaviour
{
    public Rigidbody2D rigidbodyUFO;
    public Animator anim;

    private bool move = false;
    private bool die = false;

    public float force = 200f;

    public delegate void DeathNotify();
    public event DeathNotify OnDeath;

    private Vector3 initPos;

    public UnityAction<int> OnScore;
    // Start is called before the first frame update
    void Start()
    {
        this.Idle();
        initPos = this.transform.position;
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
        this.rigidbodyUFO.simulated = false;
        this.anim.SetTrigger("Idle");
    }
    public void Jump()
    {
        this.rigidbodyUFO.simulated = true;
        this.anim.SetTrigger("Jump");
    }
    public void Man()
    {
        this.die = true;
        if(this.OnDeath!=null)
            this.OnDeath();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("ScoreRay"))
        {

        }
        else
            this.Man();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreRay"))
        {
            if (this.OnScore != null)
                this.OnScore(1);
        }
    }
    public void Init()
    {
        this.transform.position = initPos;
        this.Idle();
        this.die = false;
    }
}
