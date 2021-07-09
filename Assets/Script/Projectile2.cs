using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Transform player;
    Vector2 target;
     float distance;
    public float lifetime;
    bool isground;
    public float checkradius;
    public LayerMask Ground;
    float time,time2;
    Vector2 viruss;
    public Transform Amo2Effect;
    Animator anim;
    public int damage = 1;
    public GameObject Hitsound;
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        target = player.position;
        time = 1f;
        viruss = transform.position;
        time2 = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time2 += Time.deltaTime;
      
        int rand = Random.Range(-3, 3);
        distance = rand;
        if (time > 0 && !isground)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(viruss.x-distance, viruss.y), speed * Time.deltaTime);
        }
        time -= Time.deltaTime;
        
        
        isground = Physics2D.OverlapCircle(transform.position, checkradius, Ground);
        if (!isground && time<=0)
        {



            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        if(lifetime-time2<=0.5)
        {
            anim.Play("destroyAmo2");
             
        }

    }
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.CompareTag("Player"))
        {
            orther.GetComponent<MainCharaterControler>().health-=damage;
            orther.GetComponent<MainCharaterControler>().anim.SetTrigger("hited");
            Instantiate(Hitsound, transform.position, Quaternion.identity);
            DestroyProjectile();
           

        }


    }
    void DestroyProjectile()
    {
        Instantiate(Amo2Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
