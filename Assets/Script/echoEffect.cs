using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoEffect : MonoBehaviour
{
    // Start is called before the first frame update
    float timeBtwSpawns;
    public float starttime;
    public GameObject[] echo;
    public Transform spawnEcho;
    GameObject instance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <=0)
        {
            if (this.transform.rotation.y == 0)
            {
                 instance = (GameObject)Instantiate(echo[0], spawnEcho.position, Quaternion.identity);
            }else if (transform.rotation.y==-1)
            {
                 instance = (GameObject)Instantiate(echo[1], spawnEcho.position, Quaternion.identity);
            }
            Destroy(instance, 5f);
            timeBtwSpawns = starttime;

        }
        
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
       
    }
    
}
