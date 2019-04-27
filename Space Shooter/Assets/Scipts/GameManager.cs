using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject meteor;
    public GameObject enemy;
    public GameObject[] spawn;
    private int random;


    void Start()
    {
        random = Random.Range(0, 3);
        StartCoroutine(CreateMeteor());
        StartCoroutine(CreateEnemy());
    }


    public IEnumerator CreateMeteor()
    {
        Instantiate(meteor, spawn[random].GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        random = Random.Range(0, 3);
        StartCoroutine(CreateMeteor());
    }

    public IEnumerator CreateEnemy()
    {
        Instantiate(enemy, spawn[random].GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        random = Random.Range(0, 3);
        StartCoroutine(CreateEnemy());
    }

}
