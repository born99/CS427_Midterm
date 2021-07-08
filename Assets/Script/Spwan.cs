using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public GameObject obstacle;
    float timeBtwSpawn;
    
    public float decreaseTime;
    public float minTime;
    public Transform left;
    public Transform right;
    // Start is called before the first frame update
    public float starttime;
    
    void Start()
    {
        timeBtwSpawn = 2;
    }

    // Update is called once per frame
    void Update()
    {

        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            if (timeBtwSpawn <= 0)
            {

                Instantiate(obstacle, left.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                timeBtwSpawn = starttime;
                if(starttime>minTime)
                {
                    starttime -= decreaseTime;
                }
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        else
        {
            if (timeBtwSpawn <= 0)
            {

                Instantiate(obstacle, right.position, transform.rotation * Quaternion.Euler(0f, 0, 0f));
                timeBtwSpawn = starttime;
                if (starttime > minTime)
                {
                    starttime -= decreaseTime;
                }
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        
       
       
        

    }
}
