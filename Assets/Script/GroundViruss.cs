using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundViruss : MonoBehaviour
{
    public int damage = 2;
    public float speed;
    public Transform effect;
    public GameObject Hitsound;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyG", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            collision.GetComponent<MainCharaterControler>().health-=damage;
            collision.GetComponent<MainCharaterControler>().anim.SetTrigger("hited");
            Instantiate(Hitsound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void destroyG()
    {
        Destroy(gameObject);
    }
}
