using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharaterControler : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float speed;
     float moveinput;
    bool isGround;
    public Transform feetPos;
    public float checkradius;
    public LayerMask Ground;
    public float jumpSpeed;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveinput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(moveinput * speed, rigid.velocity.y);
    }
    void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, checkradius, Ground);
        if(isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.up * jumpSpeed;
            anim.SetTrigger("take off");
        }
        if(isGround==true)
        {
            anim.SetBool("jump", false);
        }
        else
        {
            anim.SetBool("jump", true);
        }
        if (moveinput==0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true); 
        }
        if (moveinput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(moveinput>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); 
        }
    }
    public void distroyCharacter()
    {
        Destroy(gameObject);
    }
}
