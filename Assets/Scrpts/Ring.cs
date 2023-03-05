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

    private bool[] ringsEnable = new bool[3];

    // Setup a random config
    public void Init()
    {
        for (int i = 0; i < this.ringsEnable.Length; i++)
        {
            this.ringsEnable[i] = Random.Range(0f, 1f) > 0.5f;
        }
        this.rotateSpeed0 = Random.Range(3, 18) * (Random.Range(0f, 1f) > 0.5 ? 1 : -1);
        this.rotateSpeed1 = Random.Range(3, 18) * (Random.Range(0f, 1f) > 0.5 ? 1 : -1);
        this.rotateSpeed2 = Random.Range(3, 18) * (Random.Range(0f, 1f) > 0.5 ? 1 : -1);
    }

    void Start()
    {
        float[] rotateSpeeds = {
            this.rotateSpeed0,
            this.rotateSpeed1,
            this.rotateSpeed2,
        };
        for (int i = 0; i < 3; i++)
        {
            Transform ring = transform.Find($"ring{i}");
            if (this.ringsEnable[i])
            {
                this.StartAnimate(ring, rotateSpeeds[i]);
            }
            else
            {
                ring.gameObject.SetActive(false);
            }
        }
    }

    private void StartAnimate(Transform target, float speed)
    {
        SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
        StartCoroutine(this.flash(renderer));
        StartCoroutine(this.rotate(target, speed));
    }

    private IEnumerator flash(SpriteRenderer renderer)
    {
        float alphaMax = renderer.color.a;
        float alphaMin = alphaMax / 2;
        float alpha = Random.Range(alphaMin, alphaMax);
        // loop completes in 6 sec.
        float step = (alphaMax - alphaMin) / 3;

        while (true)
        {
            while (alpha < alphaMax)
            {
                alpha += step * Time.deltaTime;
                renderer.color = this.changeAlpha(renderer.color, alpha);
                yield return null;
            }
            while (alpha > alphaMin)
            {
                alpha -= step * Time.deltaTime;
                renderer.color = this.changeAlpha(renderer.color, alpha);
                yield return null;
            }
        }
    }

    private Color changeAlpha(Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    private IEnumerator rotate(Transform target, float speed)
    {
        while (true)
        {
            target.eulerAngles += Vector3.forward * (speed * Time.deltaTime);
            yield return null;
        }
    }
}
