using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera c;
    [SerializeField]
    private Vector2 robotspeed;
    [SerializeField]
    private float distance;
    void Start()
    {
        transform.position = c.transform.position - new Vector3(0,distance,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(robotspeed);
        if(transform.position.y<c.transform.position.y-distance){
            transform.position = c.transform.position - new Vector3(0,distance,0);
        }
    }
}
