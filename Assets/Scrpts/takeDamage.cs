using System.Collections;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int HP, MaxHP;
    [SerializeField] bool canTakeDamage;
    [SerializeField] float takeDamageCoolDown;

    void Start()
    {
        HP = MaxHP;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacle" && canTakeDamage)
        {
            Debug.Log(1);
            StartCoroutine(this.takingDamage());
        }
        if (other.gameObject.tag == "")
        {
            HP++;
        }
    }

    private IEnumerator takingDamage()
    {
        canTakeDamage = false;
        HP--;
        yield return new WaitForSeconds(takeDamageCoolDown);
        canTakeDamage = true;
    }
}
