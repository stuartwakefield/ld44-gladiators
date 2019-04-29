using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource source;

    private static AudioSource music;

    void Awake()
    {
        if (music != null)
        {
            Destroy(this.gameObject);
        } else
        {
            music = source;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            music.Stop();
        }
        else if (!music.isPlaying)
        {
            music.Play();
        }
    }
}
