using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misile2 : MonoBehaviour
{
    public int speed;
    public int lifetime;

    void Start()
    {
        speed = -9;
        lifetime = 2;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        StartCoroutine(DestroyBullet());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
