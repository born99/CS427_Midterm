using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundViruss : MonoBehaviour
{
    public int damage = 1;
    public float speed;
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
            Destroy(gameObject);
            collision.GetComponent<MainCharaterControler>().distroyCharacter();
        }
    }
    void destroyG()
    {
        Destroy(gameObject);
    }
}
