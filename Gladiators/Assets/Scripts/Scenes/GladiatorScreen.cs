using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GladiatorScreen : MonoBehaviour
{
    public Text levelOutput;
    public Text battlesOutput;
    public Text survivalTimeOutput;
    public Text damageDealtOutput;
    public Text damageTakenOutput;
    public Text marketValueOutput;

    private static string[] LEVEL_TEXT = new string[]
    {
        "Diseased slave",
        "Rotten slave",
        "Infested slave",
        "Dirty slave",
        "Scrapper",
        "Fighter",
        "Best fighter",
        "Gladiator",
        "Spectacle",
        "Champion"
    };

    private static float[] LEVEL_VALUE = new float[]
    {
        1000.0f,
        2000.0f,
        3000.0f,
        4000.0f,
        5000.0f,
        6000.0f,
        7000.0f,
        8000.0f,
        9000.0f
    };

    public void Start()
    {
        float value = PlayerInfoContainer.Info.GetValue(Time.time);
        string level = LEVEL_TEXT[GetLevel(value)];

        levelOutput.text = level;
        battlesOutput.text = PlayerInfoContainer.Info.GetBattleCount().ToString();
        survivalTimeOutput.text = Mathf.Floor(PlayerInfoContainer.Info.GetSurvivalTime()).ToString();
        marketValueOutput.text = value.ToString();
    }

    private int GetLevel(float value)
    {
        for (int i = 0; i < LEVEL_VALUE.Length; i++)
        {
            if (LEVEL_VALUE[i] > value)
            {
                return i;
            }
        }
        return LEVEL_TEXT.Length - 1;
    }

    public void OnNext()
    {
        SceneManager.LoadScene("Battle");
    }
}
