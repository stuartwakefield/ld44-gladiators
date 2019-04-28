using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public BattleScene battle;

    public void OnPlayerDead()
    {
        battle.OnDeath();
    }
}
