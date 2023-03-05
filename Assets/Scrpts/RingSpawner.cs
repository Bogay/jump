using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    [SerializeField]
    private Ring ring;
    [SerializeField]
    private float verticalInterval;
    [SerializeField]
    private float offsetY;
    [SerializeField]
    private Vector2 boundX;
    [SerializeField]
    private float jitterRange;
    private float jitter => Random.Range(-this.jitterRange, this.jitterRange);

    private float lastSpawnY;

    void Start()
    {
        this.lastSpawnY = transform.position.y;
        this.spawnRings(1);
    }

    private void spawnRings(int iteration)
    {
        while (iteration-- > 0)
        {
            float x = Random.Range(this.boundX.x, this.boundX.y) + this.jitter;
            float y = this.lastSpawnY + this.offsetY + this.jitter;

            Ring r = Instantiate(this.ring, new Vector3(x, y, 0), Quaternion.identity);
            r.Init();
            r.transform.localScale = Vector3.one * Random.Range(1.2f, 1.6f);

            this.lastSpawnY = y;
        }
    }

    void Update()
    {
        if (transform.position.y > this.lastSpawnY)
        {
            this.spawnRings(3);
        }
    }
}
