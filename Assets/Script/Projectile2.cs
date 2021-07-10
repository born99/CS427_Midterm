using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Transform player;
    Vector2 target;
    public float distance;
    public float lifetime;
    bool isground;
    public float checkradius;
    public LayerMask Ground;
    float time;
    Vector2 viruss;
    public Transform amo2effect;
    public int damage;
    public GameObject Hitsound;
    float starttime;
    Animator anim;
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        time = 1f;
        viruss = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        starttime += Time.deltaTime;
        if(lifetime-starttime<=0.5)
        {
            anim.SetTrigger("destroy");
        }    
        if (time > 0 && !isground)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(viruss.x, viruss.y - distance), speed * Time.deltaTime);
        }
        time -= Time.deltaTime;
       
        
        isground = Physics2D.OverlapCircle(transform.position, checkradius, Ground);
        if (!isground && time<=0)
        {



            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.CompareTag("Player"))
        {
            orther.GetComponent<MainCharaterControler>().health -= damage;
            orther.GetComponent<MainCharaterControler>().anim.SetTrigger("hited");
            Instantiate(Hitsound, transform.position, Quaternion.identity);
            DestroyProjectile();
           

        }


    }
    void DestroyProjectile()
    {
        Instantiate(amo2effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
