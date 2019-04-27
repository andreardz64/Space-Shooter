using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject misile;
    public GameObject shootPoint;
    public int life;

    private void Start()
    {
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
        if (collision.gameObject.name == "Misile1")
        {
            life=life-1 ;
            if (life == 0)
            {
                Destroy(gameObject);
            }
        }
       
    }




}
