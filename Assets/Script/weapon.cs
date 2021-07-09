using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    
    public GameObject projectile;
    float timeBwtshots;
    public float starttimeBtwShots;
    public float offset;
    public Transform shotpoint;
    Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBwtshots = starttimeBtwShots;
        target = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diffe = player.position - transform.position;
        float rotZ = Mathf.Atan2(diffe.y, diffe.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBwtshots <= 0)
        {
            Instantiate(projectile, shotpoint.position, transform.rotation);
            timeBwtshots = starttimeBtwShots;
        }
        else
        {
            timeBwtshots -= Time.deltaTime;
        }

    }

}
