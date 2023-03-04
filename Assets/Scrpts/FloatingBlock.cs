using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour
{
    private Vector3 scale;
    private Vector3 velocity;
    private Vector3 rotate;

    void Update()
    {
        transform.Translate(this.velocity * Time.deltaTime);
        transform.Rotate(this.rotate * Time.deltaTime);
    }

    public void Init(Vector3 scale, Vector3 velocity, Vector3 rotate)
    {
        this.scale = scale;
        transform.localScale = scale;

        this.velocity = velocity;
        this.rotate = rotate;
    }
}
