using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : MonoBehaviour
{
    public Animator animator;
    public PlayerInfoManager manager;
    public LevelManager levelManager;
    public float wait = 5.0f;

    private float start = 0.0f;
    private bool death = false;
    private bool victory = false;

    public void Start()
    {
        manager.OnBattleStart();
        levelManager.LoadLevel(Time.time);
    }

    public void OnDeath()
    {
        start = Time.time;
        death = true;
        animator.SetTrigger("Death");
        manager.OnDeath();
    }

    public void OnVictory()
    {
        start = Time.time;
        victory = true;
        animator.SetTrigger("Victory");
        manager.OnVictory();
    }

    public void Update()
    {
        if (death && Time.time > start + wait)
        {
            SceneManager.LoadScene("Start", LoadSceneMode.Single);
        }
        else if (victory && Time.time > start + wait)
        {
            SceneManager.LoadScene("Arena", LoadSceneMode.Single);
        }
    }
}
