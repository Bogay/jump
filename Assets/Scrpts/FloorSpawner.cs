using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;

    [SerializeField]
    private float verticalInterval;
    [SerializeField]
    private float offsetY;

    [SerializeField]
    private float leftX;
    [SerializeField]
    private float midX;
    [SerializeField]
    private float rightX;
    [SerializeField]
    private float jitterRange;
    private float jitter => Random.Range(-this.jitterRange, this.jitterRange);

    [SerializeField]
    private int lastSpawnSlots;

    private float lastSpawnY;

    void Start()
    {
        this.lastSpawnY = transform.position.y;
    }

    private bool validSlot(int s)
    {
        if ((s & this.lastSpawnSlots) != 0)
            return false;
        if ((s | this.lastSpawnSlots) == 0b101)
            return false;
        return true;
    }

    private int decideSpawnSlots()
    {
        int slots = (~this.lastSpawnSlots) & 7;
        return (new[] { 1, 2, 4, 5 }).Where(this.validSlot).OrderBy(_ => Random.Range(0, 666)).Take(1).Single();
    }

    private GameObject spawnFloor(float x)
    {
        x += this.jitter;
        float y = transform.position.y + this.offsetY + this.jitter;
        Debug.Log($"new floor spawned. [pos=({x}, {y})]");
        return Instantiate(this.floor, new Vector3(x, y, 0), Quaternion.identity);
    }

    void Update()
    {
        if (transform.position.y > this.lastSpawnY)
        {
            int slots = this.decideSpawnSlots();
            if ((slots & 1) != 0)
                this.lastSpawnY = Mathf.Max(this.lastSpawnY, this.spawnFloor(this.leftX).transform.position.y);
            if ((slots & 2) != 0)
                this.lastSpawnY = Mathf.Max(this.lastSpawnY, this.spawnFloor(this.midX).transform.position.y);
            if ((slots & 4) != 0)
                this.lastSpawnY = Mathf.Max(this.lastSpawnY, this.spawnFloor(this.rightX).transform.position.y);
            this.lastSpawnSlots = slots;
            Debug.Log($"slots updated. [val={slots}]");
        }
    }
}
