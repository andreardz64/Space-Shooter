using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject misile;
    public GameObject shootPoint;
    public int life;
    public float speed;
    private GameObject ship;
    public float shipX;
    public float shipY;
    public int lifetime;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        speed = 0.5f;
        lifetime = 5;
        shipX = ship.transform.position.x;
        shipY = ship.transform.position.y;
        life = 3;
        StartCoroutine(Shoot());
        StartCoroutine(DestroyBullet());
    }

    public IEnumerator Shoot()
    {
        Instantiate(misile, shootPoint.GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Shoot());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name ==  "Misile1(Clone)")
        {
            life = life - 1;
            if (life <= 0) Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }


    void Update()
    {
       
        Move();
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = NormalizeSpeed (shipX - transform.position.x, shipY - transform.position.y);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    protected Vector2 NormalizeSpeed(float x, float y)
    {
        float xSpeed;
        float ySpeed;
        if (x != 0 && y != 0)
        {
            xSpeed = Mathf.Sin(Mathf.PI / 4) * speed * x;
            ySpeed = Mathf.Sin(Mathf.PI / 4) * speed * y;
        }
        else
        {
            xSpeed = x != 0 ? speed * x : 0;
            ySpeed = y != 0 ? speed * y : 0;
        }

        return new Vector2(xSpeed, ySpeed);
    }

}
