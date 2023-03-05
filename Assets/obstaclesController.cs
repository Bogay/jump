using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesController : MonoBehaviour
{
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target.tag = "hit";
        }
        if (other.gameObject.CompareTag("ground"))
        {
            gameObject.tag = "hit";
        }
    }
}
