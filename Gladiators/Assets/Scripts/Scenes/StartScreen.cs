using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public PlayerInfoManager manager;

    public void OnStart()
    {
        manager.OnStart();
        SceneManager.LoadScene("Arena", LoadSceneMode.Single);
    }
}
