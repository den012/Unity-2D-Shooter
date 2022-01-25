using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 20f;
    public Rigidbody2D rb;

    public GameObject impactEffect;
    public int damage = 100;

    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitinfo)
    {
        Monsters monster = hitinfo.GetComponent<Monsters>();
        if(monster != null)
        {
            monster.TakeDamage(damage);
        }

        Destroy(gameObject);
        score+=1;
        Debug.Log(score);

    }
}
