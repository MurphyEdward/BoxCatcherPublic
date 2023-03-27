using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    
    private const string UniversalLevelName = "Level 1";

    [SerializeField] private LevelSettings _settings;
    [Range(0, 3)] private int _stars = 0;

    public int Stars => _stars;

    private void Awake()
    {
        _stars = LevelPlayerPrefs.GetLevelStars(_settings.Number);
    }

    public void StartLevel()
    {
        _settings.IsChosenLevel = true;
        SceneManager.LoadScene(UniversalLevelName);
    }
}
