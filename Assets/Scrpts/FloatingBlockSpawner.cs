using System.Collections;
using UnityEngine;

public class FloatingBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 boundMin;
    [SerializeField]
    private Vector2 boundMax;
    [SerializeField]
    private GameObject block;

    void Start()
    {
        StartCoroutine(this.spawnLoop());
    }

    private IEnumerator spawnLoop()
    {
        while (true)
        {
            float x = Random.Range(this.boundMin.x, this.boundMax.x);
            float y = Random.Range(this.boundMin.y, this.boundMax.y);
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            float ratio = Random.Range(1.2f, 2.4f);
            Vector3 scale = new Vector3(1, ratio, 1) * Random.Range(20, 40);

            GameObject go = Instantiate(this.block, pos, Quaternion.identity);
            FloatingBlock fBlock = go.GetComponent<FloatingBlock>();
            fBlock.Init(scale, Vector3.down * Random.Range(1f, 5f), Vector3.zero);

            float wait = Random.Range(0.05f, 0.3f);
            yield return new WaitForSeconds(wait);
        }
    }
}
