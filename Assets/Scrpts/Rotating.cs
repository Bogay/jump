using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    private Transform transformer;
    public Vector3 angle;
    private bool detecter = false;
    private Vector3 zero = new Vector3(0, 0, 0);
    void Start()
    {
        this.transformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.detecter == true)
        {
            this.transformer.Rotate(zero);
        }
        else
        {
            this.transformer.Rotate(angle);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground")||other.gameObject.CompareTag("gasoline-can"))
        {
            this.detecter = true;
        }
    }
}
