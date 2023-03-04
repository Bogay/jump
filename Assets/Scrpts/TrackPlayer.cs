using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        if (this.player.position.y > transform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = this.player.position.y;
            transform.position = newPos;
        }
    }
}
