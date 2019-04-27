using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorScreen : MonoBehaviour
{
    public void OnNext()
    {
        Debug.Log("Next");
        SceneManager.LoadScene("Battle");
    }
}
