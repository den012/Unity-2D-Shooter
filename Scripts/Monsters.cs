using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody;

    public int health = 100;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effectClone = Instantiate(deathEffect, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        Destroy(effectClone, 0.1f);
        Destroy(gameObject);
    }
}
