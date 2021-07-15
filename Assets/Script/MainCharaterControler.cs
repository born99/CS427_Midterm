using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class MainCharaterControler : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text[] score;
    Rigidbody2D rigid;
    public float speed;
     float moveinput;
    bool isGround;
    public Transform feetPos;
    public float checkradius;
    public LayerMask Ground;
    public float jumpSpeed;
    public Animator anim;
    public GameObject ground;
    public float startDashtime;
    float dashtime;
    float timeSurive;
    bool dash = false;
    bool movingR;
    public float dashDistance;
    public GameObject gameover;
    public int health=3;
    public int numOfheart=3;
    public Image[] healths;
    public Sprite fullhearth;
    public Sprite emptyhearth;
    public GameObject[] sound;
    public GameObject light;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timeSurive += Time.deltaTime;
        moveinput = Input.GetAxisRaw("Horizontal");
        if (dash == false)
        {
            rigid.velocity = new Vector2(moveinput * speed, rigid.velocity.y);
        }
        score[0].text = timeSurive.ToString("0.00");
        score[1].text = timeSurive.ToString("0.00");
        if(health<=0)
        {
            
            Instantiate(sound[0], transform.position, Quaternion.identity);
            distroyCharacter();
        }
        
    }
    void Update()
    {
        
        for (int i = 0; i < healths.Length; i++)
        {
            if(i<health)
            {
                healths[i].sprite = fullhearth;
            }
            else
            {
                healths[i].sprite = emptyhearth;
            }
            if(i<numOfheart)
            {
                healths[i].enabled = true;
            }
            else
            {
                healths[i].enabled = false;
            }
        }

        isGround = Physics2D.OverlapCircle(feetPos.position, checkradius, Ground);
        if(isGround == true && Input.GetKeyDown(KeyCode.Space) && !dash)
        {
            rigid.velocity = Vector2.up * jumpSpeed;
            Instantiate(sound[1], transform.position, Quaternion.identity);
            anim.SetTrigger("take off");
        }
        if(isGround==true)
        {
            light.SetActive(true);
            anim.SetBool("jump", false);
        }
        else
        {
            light.SetActive(false);
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
                Instantiate(sound[2], transform.position, Quaternion.identity);
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
      
        
        
      
        
    }
    IEnumerator Dash(float di)
    {
        dash = true;
        anim.SetTrigger("dash");
        this.GetComponent<echoEffect>().enabled = true;
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(new Vector2(dashDistance * di, 0f), ForceMode2D.Impulse);
        float gravity = rigid.gravityScale;
        rigid.gravityScale = 0;
        yield return new WaitForSeconds(0.5f);
        dash = false;
        rigid.gravityScale = gravity;
        this.GetComponent<echoEffect>().enabled = false;

    }
    public void distroyCharacter()
    {

        gameover.SetActive(true);
        
        Destroy(gameObject);
    }

}
