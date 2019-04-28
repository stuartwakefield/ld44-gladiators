using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public GameObject parent;
    public EnemyManager manager;

    public void Start()
    {
        manager.AddEnemy(parent);
    }

    public void OnDead()
    {
        manager.OnEnemyDead(parent);
    }
}
