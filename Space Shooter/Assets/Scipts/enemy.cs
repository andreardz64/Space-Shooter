using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject misile;
    public GameObject shootPoint;
    public int life;
    public GameObject ship;
    public float shipX;
    public float shipY;
   


    void Start()
    {
        shipX = ship.transform.position.x;
        shipY = ship.transform.position.y;
        life = 3;
        StartCoroutine(Shoot());
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
        GetComponent<Rigidbody2D>().velocity = new Vector2 (shipX - transform.position.x, shipY - transform.position.y);
    }




}
