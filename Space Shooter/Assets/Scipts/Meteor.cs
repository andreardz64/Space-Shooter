using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public int lifetime;
    public int life;

    void Start()
    {
        life = 5;
        lifetime = 4;
        speed = -0.05f;
        StartCoroutine(DestroyBullet());
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += speed;
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Misile1")
        {
            life=life-1;
        }
        if (life==0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}

