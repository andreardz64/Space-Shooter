using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misile1 : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;
    public int lifetime;

    void Start()
    {
        speed = 9;
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
