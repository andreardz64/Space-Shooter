using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float life;
    public int speed;
    public GameObject shootPoint;
    public GameObject misile;
    private Color characterColor;

    private void Awake()
    {
        life = 5;
        characterColor = gameObject.GetComponent<SpriteRenderer>().color;
        speed = 8;
    }

    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMove * speed, verticalMove * speed);

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        StartCoroutine(RestoreColor());
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        life= life-1;
        if (life <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log("Game Over");
    }

    public IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = characterColor;
    }

    void Shoot()
    {
        Instantiate(misile, shootPoint.GetComponent<Transform>().position, Quaternion.identity);

    }

}
