using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeDamage : MonoBehaviour
{
    public int HP,MaxHP;
    [SerializeField] bool canTakeDamage;
    [SerializeField] float takeDamageCoolDown;
    public Image[] heart;
    public Sprite fullheart;
    public Sprite emptyheart;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP>MaxHP){
            HP = MaxHP;
        }
        for(int i = 0; i < heart.Length;i++){
            if(i < MaxHP){
                heart[i].enabled = true;
            }
            else{
                heart[i].enabled = false;
            }

            if(i<HP){
                heart[i].sprite = fullheart;
            }
            else{
                heart[i].sprite = emptyheart;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "gasoline-can" && canTakeDamage){
            StartCoroutine("takingDamage");
        }
        if(other.gameObject.tag == ""){
            HP++;
        }
    }
    private IEnumerator takingDamage(){
        canTakeDamage = false;
        HP--;
        yield return new WaitForSeconds(takeDamageCoolDown);
        canTakeDamage = true;
    }
}
