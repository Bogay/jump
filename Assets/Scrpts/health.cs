using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    public int Hp;
    public int numOfHeart;
    public Image[] heart;
    public Sprite fullheart;
    public Sprite emptyheart;
    void Update(){
        for(int i = 0; i < heart.Length;i++){
            if(i < numOfHeart){
                heart[i].enabled = true;
            }
            else{
                heart[i].enabled = false;
            }
        }
    }

}
