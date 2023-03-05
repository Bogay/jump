using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMovement : MonoBehaviour
{
    [SerializeField]
    private Camera c;
    [SerializeField]
    private Vector2 robotspeed;
    [SerializeField]
    private float distance;

    void Start()
    {
        transform.position = this.cacluatePosition();
    }

    void Update()
    {
        transform.Translate(robotspeed * Time.deltaTime);
    }

    private Vector3 cacluatePosition()
    {
        Vector3 p = this.c.transform.position - new Vector3(0, distance, 0);
        p.z = 0;
        return p;
    }
}
