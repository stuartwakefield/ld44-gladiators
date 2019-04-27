using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void OnStart()
    {
        Debug.Log("Starting new game");
        SceneManager.LoadScene("Arena", LoadSceneMode.Single);
    }
}
