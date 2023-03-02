using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private takeDamage stat;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    private int maxHp => this.stat.MaxHP;
    private int hp => this.stat.HP;

    void Update()
    {
        this.showSprites(this.hp, this.maxHp);
    }

    private void showSprites(int hp, int maxHp)
    {
        int childCount = transform.childCount;
        for (int i = childCount + 1; i <= maxHp; i++)
        {
            GameObject go = new GameObject($"HP {i}");
            go.transform.SetParent(transform);
            Image img = go.AddComponent<Image>();
            img.sprite = this.emptyHeart;
        }

        for (int i = maxHp; i < childCount; i++)
        {
            Destroy(transform.GetChild(i));
        }

        for (int i = 0; i < hp; i++)
        {
            transform.GetChild(i).GetComponent<Image>().overrideSprite = this.fullHeart;
        }

        for (int i = hp; i < maxHp; i++)
        {
            transform.GetChild(i).GetComponent<Image>().overrideSprite = this.emptyHeart;
        }
    }
}
