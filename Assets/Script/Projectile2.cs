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
    float time;
    Vector2 viruss;
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        time = 1f;
        viruss = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
        Destroy(gameObject);
    }
}
