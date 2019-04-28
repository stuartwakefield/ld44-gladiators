using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GladiatorScreen : MonoBehaviour
{
    public Text battlesOutput;
    public Text survivalTimeOutput;
    public Text damageDealtOutput;
    public Text damageTakenOutput;
    public Text marketValueOutput;

    public void Start()
    {
        battlesOutput.text = PlayerInfoContainer.Info.GetBattleCount().ToString();
        survivalTimeOutput.text = Mathf.Floor(PlayerInfoContainer.Info.GetSurvivalTime()).ToString();
        damageDealtOutput.text = Mathf.Floor(PlayerInfoContainer.Info.GetDamageDealt()).ToString();
        damageTakenOutput.text = Mathf.Floor(PlayerInfoContainer.Info.GetDamageTaken()).ToString();
        marketValueOutput.text = PlayerInfoContainer.Info.GetValue(Time.time).ToString();
    }

    public void OnNext()
    {
        SceneManager.LoadScene("Battle");
    }
}
