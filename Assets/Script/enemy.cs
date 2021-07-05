using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    public float distance;
    public GameObject projectile;
    float timeBwtshots;
    public float starttimeBtwShots;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBwtshots = starttimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position)> stoppingDistance)
        {
            if (transform.position.y > distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
            }
            
        }
        else if(Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position,player.position)>retreatDistance)
            {
            transform.position = this.transform.position;

        } else if (Vector2.Distance(transform.position,player.position)<retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if(timeBwtshots<=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBwtshots = starttimeBtwShots;
        }
        else
        {
            timeBwtshots -= Time.deltaTime;
        }
      
    }

}
