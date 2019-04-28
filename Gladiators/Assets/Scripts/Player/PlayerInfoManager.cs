using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public void OnStart()
    {
        PlayerInfoContainer.Info.OnStart();
    }

    public void OnBattleStart()
    {
        PlayerInfoContainer.Info.OnBattleStarted(Time.time);
    }

    // TODO
    public void OnDamageTaken(float amount)
    {
        PlayerInfoContainer.Info.OnDamageTaken(amount);
    }

    // TODO
    public void OnDamageGiven(float amount)
    {
        PlayerInfoContainer.Info.OnDamageGiven(amount);
    }

    // TODO
    public void OnWeaponPickup()
    {
        PlayerInfoContainer.Info.OnWeaponPickup();
    }

    public void OnVictory()
    {
        PlayerInfoContainer.Info.OnVictory(Time.time);
    }

    public void OnDeath()
    {
        PlayerInfoContainer.Info.OnDeath();
    }

    public int GetValue()
    {
        return (int) Mathf.Floor(PlayerInfoContainer.Info.GetValue(Time.time));
    }
}
