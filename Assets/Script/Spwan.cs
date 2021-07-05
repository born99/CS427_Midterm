using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public GameObject obstacle;
    float timeBtwSpawn;
    float startTime;
    public float decreaseTime;
    public float minTime;
    public Transform left;
    public Transform right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(5, 10);
        startTime = rand;
        if (timeBtwSpawn <=0)
        {

            Instantiate(obstacle, left.position,transform.rotation*Quaternion.Euler(0f,180f,0f ));
            timeBtwSpawn = startTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        int rand2 = Random.Range(5, 10);
        startTime = rand;
        if (timeBtwSpawn <= 0)
        {

            Instantiate(obstacle, right.position, transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            timeBtwSpawn = startTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
