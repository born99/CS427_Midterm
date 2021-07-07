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
    public GameObject ground;
    public float startDashtime;
    float dashtime;
    
    bool dash = false;
    bool movingR;
    public float dashDistance;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveinput = Input.GetAxisRaw("Horizontal");
        if (dash == false)
        {
            rigid.velocity = new Vector2(moveinput * speed, rigid.velocity.y);
        }
    }
    void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, checkradius, Ground);
        if(isGround == true && Input.GetKeyDown(KeyCode.Space) && !dash)
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
        if (moveinput==0 && isGround)
        {
            anim.SetBool("run", false);
        }
        else
        if(isGround)
        {
            anim.SetBool("run", true); 
        }
        if (moveinput < 0 && !dash)
        {
            movingR = false;
            transform.eulerAngles = new Vector3(0, 180, 0);
            
          

        }
        else if(moveinput>0 && !dash)
        {

            movingR = true;
            
            
            transform.eulerAngles = new Vector3(0, 0, 0); 
        }
        
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (dashtime <= 0)
            {
                if (movingR)
                {
                    StartCoroutine(Dash(1));
                }
                else
                {
                    StartCoroutine(Dash(-1));
                }
                dashtime = startDashtime;
            }
            
            
        }
        else
        {
            dashtime -= Time.deltaTime;
        }
        Debug.Log(dashtime);
        
        
      
        
    }
    IEnumerator Dash(float di)
    {
        dash = true;
        anim.SetTrigger("dash");
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(new Vector2(dashDistance * di, 0f), ForceMode2D.Impulse);
        float gravity = rigid.gravityScale;
        rigid.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        dash = false;
        rigid.gravityScale = gravity;

    }
    public void distroyCharacter()
    {
        Destroy(gameObject);
    }
}
