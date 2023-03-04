using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed0;
    [SerializeField]
    private float rotateSpeed1;
    [SerializeField]
    private float rotateSpeed2;

    void Start()
    {
        StartCoroutine(this.rotateLoop(transform.Find("ring0"), this.rotateSpeed0));
        StartCoroutine(this.rotateLoop(transform.Find("ring1"), this.rotateSpeed1));
        StartCoroutine(this.rotateLoop(transform.Find("ring2"), this.rotateSpeed2));
    }

    private IEnumerator rotateLoop(Transform target, float speed)
    {
        while (true)
        {
            target.eulerAngles += Vector3.forward * (speed * Time.deltaTime);
            yield return null;
        }
    }
}
