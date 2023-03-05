using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]
    private float goalHeight;
    [SerializeField]
    private takeDamage player;

    void Update()
    {
        if (player.HP == 0)
        {
            GameObject go = new GameObject();
            go.AddComponent<ChangeScene>().Go("GG");
        }
        if (player.transform.position.y >= this.goalHeight)
        {
            GameObject go = new GameObject();
            go.AddComponent<ChangeScene>().Go("Win");
        }
    }
}
