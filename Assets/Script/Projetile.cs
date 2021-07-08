using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetile : MonoBehaviour
{
    public float speed;
    Transform player;
    Vector2 target;
    public float distance;
    public float lifetime;
    bool isground;
    public float checkradius;
    public LayerMask Ground;
    public Transform amoEffect;
     Animator anim ;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        anim = GetComponent<Animator>();
        time = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        isground = Physics2D.OverlapCircle(transform.position, checkradius, Ground);
        if (!isground)
        {



            transform.Translate(Vector2.down * speed * Time.deltaTime);
            
        }
        if(isground)
        {
            anim.Play("amo1");
        }
       

    }
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.CompareTag("Player"))
        {
            orther.GetComponent<MainCharaterControler>().distroyCharacter();
            DestroyProjectile();

        }
       
     
       
    }
    
    void DestroyProjectile()
    {
        Instantiate(amoEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
}
