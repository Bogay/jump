using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    void Start()
    {
        SceneAudioManager.instance.PlayByName("BGM");
    }
}
