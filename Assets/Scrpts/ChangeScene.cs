using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Go(string name)
    {
        SceneManager.LoadScene(name);
        SceneAudioManager.instance.StopAll();
    }
}
