using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour
{
    public PlayerInfoManager manager;
    public Text text;
    private string suffix;

    private void Start()
    {
        suffix = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = manager.GetValue().ToString() + suffix;
    }
}
