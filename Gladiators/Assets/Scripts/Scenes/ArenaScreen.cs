﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaScreen : MonoBehaviour
{
    public void OnNext()
    {
        SceneManager.LoadScene("Gladiator", LoadSceneMode.Single);
    }
}
