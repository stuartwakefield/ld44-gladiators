using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    private List<(float, Level)> levels = new List<(float, Level)>();

    public void AddLevel(Level level, float value)
    {
        levels.Add((value, level));
    }

    public void LoadLevel(float t)
    {
        levels.OrderByDescending(l => l.Item1).Where(l => l.Item1 <= PlayerInfoContainer.Info.GetValue(t)).First().Item2.Load();
    }
}
