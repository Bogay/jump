using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{

    [SerializeField] GameObject[] obstaclesPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minX, maxX);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(obstaclesPrefab[Random.Range(0, obstaclesPrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
    
}
