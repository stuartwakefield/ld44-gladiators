using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    void OnPlayerDead()
    {
        Debug.Log("Death!");
    }

    void OnEnemyDead()
    {
        Debug.Log("Victory!");
    }
}
