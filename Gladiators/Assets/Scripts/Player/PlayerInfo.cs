using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private static float START_VALUE = 100.0f;
    private static float DAMAGE_TAKEN_BONUS = 5.0f;
    private static float DAMAGE_GIVEN_BONUS = 20.0f;
    private static float WEAPON_PICKUP_BONUS = 10.0f;
    private static float SURVIVE_TIME_BONUS = 1.0f;
    private static float VICTORY_BONUS = 100.0f;

    private float start = -1.0f;
    private float value = START_VALUE;

    public void OnStart()
    {
        value = START_VALUE;
    }

    public void OnDamageTaken(float amount)
    {
        value += amount * DAMAGE_TAKEN_BONUS;
    }

    public void OnDamageGiven(float amount)
    {
        value += amount * DAMAGE_GIVEN_BONUS;
    }

    public void OnWeaponPickup()
    {
        value += WEAPON_PICKUP_BONUS;
    }

    public void OnBattleStarted(float t)
    {
        start = t;
    }

    public void OnVictory(float t)
    {
        start = -1.0f;
        value += t - start * SURVIVE_TIME_BONUS + VICTORY_BONUS;
    }

    public void OnDeath()
    {
        start = -1.0f;
        value = 0.0f;
    }

    public float GetValue(float t)
    {
        if (start > -1.0)
        {
            return value + t - start * SURVIVE_TIME_BONUS;
        }
        return value;
    }
}
