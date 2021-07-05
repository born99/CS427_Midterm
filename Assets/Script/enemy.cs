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
    public GameObject[] projectile;
    float timeBwtshots;
    public float starttimeBtwShots;
    public float offset;
    public Transform[] shotpoint;
    public float decreaseTime;
    public float minTime=0.8f;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBwtshots = starttimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
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
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

      
        if(timeBwtshots<=0)
        {
            int rand = Random.Range(0, 10);
            if (rand < 2)
            {
                Instantiate(projectile[1], shotpoint[1].position, Quaternion.identity);
                Instantiate(projectile[0], shotpoint[0].position, Quaternion.identity);
            }else if(rand < 5)
            {
                Instantiate(projectile[0], shotpoint[1].position, Quaternion.identity);
                Instantiate(projectile[0], shotpoint[0].position, Quaternion.identity);
            }
            else
            {
                int r = Random.Range(0, projectile.Length);
                Instantiate(projectile[r], shotpoint[r].position, Quaternion.identity);
            }
            timeBwtshots = starttimeBtwShots;
            if(starttimeBtwShots>minTime)
            {
                starttimeBtwShots -= decreaseTime;
            }
        }
        else
        {
            timeBwtshots -= Time.deltaTime;
        }
      
    }

}
