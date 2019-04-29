using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float value;
    public GameObject battle;
    public LevelManager manager;

    void Awake()
    {
        manager.AddLevel(this, value);
    }

    public void Load()
    {
        battle.SetActive(true);
    }
}
