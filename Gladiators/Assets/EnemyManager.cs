using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public BattleScene battle;
    private List<GameObject> enemies = new List<GameObject>();

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void OnEnemyDead(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            battle.OnVictory();
        }
    }
}
