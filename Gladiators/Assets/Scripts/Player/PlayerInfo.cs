using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private static float START_VALUE = 100.0f;

    private static float DAMAGE_TAKEN_BONUS = 20.0f;
    private static float DAMAGE_TAKEN_PER = 10.0f;

    private static float DAMAGE_GIVEN_BONUS = 20.0f;
    private static float DAMAGE_GIVEN_PER = 10.0f;

    private static float WEAPON_PICKUP_BONUS = 10.0f;
    private static float WEAPON_PICKUP_PER = 1.0f;

    private static float SURVIVE_TIME_BONUS = 10.0f;
    private static float SURVIVE_TIME_PER = 10.0f;

    private static float VICTORY_BONUS = 100.0f;

    private float survivalTime = 0.0f;
    private float damageTaken = 0.0f;
    private float damageGiven = 0.0f;
    private int weaponPickups = 0;
    private int battles = 0;

    private float start = -1.0f;

    public float GetSurvivalTime()
    {
        return survivalTime;
    }

    public float GetDamageTaken()
    {
        return damageTaken;
    }

    public float GetDamageDealt()
    {
        return damageGiven;
    }

    public int GetBattleCount()
    {
        return battles;
    }

    public void OnStart()
    {
        survivalTime = 0.0f;
        damageTaken = 0.0f;
        damageGiven = 0.0f;
        weaponPickups = 0;
        battles = 0;
    }

    public void OnDamageTaken(float amount)
    {
        damageTaken += amount;
    }

    public void OnDamageGiven(float amount)
    {
        damageGiven += amount;
    }

    public void OnWeaponPickup()
    {
        weaponPickups++;
    }

    public void OnBattleStarted(float t)
    {
        start = t;
    }

    public void OnVictory(float t)
    {
        survivalTime += t - start;
        battles++;
        start = -1.0f;
    }

    public void OnDeath()
    {
        start = -1.0f;
    }

    public float GetValue(float t)
    {
        return START_VALUE + GetSurvivalTimeBonus() + GetDamageTakenBonus() + GetDamageGivenBonus() + 
            GetWeaponPickupBonus() + GetBattleCountBonus();
    }

    private float GetSurvivalTimeBonus()
    {
        return Mathf.Floor(survivalTime / SURVIVE_TIME_PER) * SURVIVE_TIME_BONUS;
    }

    private float GetDamageTakenBonus()
    {
        return Mathf.Floor(damageTaken / DAMAGE_TAKEN_PER) * DAMAGE_TAKEN_BONUS;
    }

    private float GetDamageGivenBonus()
    {
        return Mathf.Floor(damageGiven / DAMAGE_GIVEN_PER) * DAMAGE_GIVEN_BONUS;
    }

    private float GetWeaponPickupBonus()
    {
        return Mathf.Floor(weaponPickups / WEAPON_PICKUP_PER) * WEAPON_PICKUP_BONUS;
    }

    private float GetBattleCountBonus()
    {
        return battles * VICTORY_BONUS;
    }
}
