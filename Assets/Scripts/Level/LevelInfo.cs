using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LevelInfo : MonoBehaviour
{
    
    private const float HundredPercent = 1.0f;
    private const float _minPercentsCaughtToWin = 0.70f;
    private const string LevelsFolder = "Levels";

    [SerializeField] private BoxSpawner _boxSpawner;
    [SerializeField] private GameObject[] _starObjects = new GameObject[3];
    [SerializeField] private UnityEvent levelStarted;
    [SerializeField] private UnityEvent levelWon;
    [SerializeField] private UnityEvent levelLost;

    private LevelSettings _settings;
    private int _minBoxesToCatch;
    private int _score;
    private int _stars;
    private string _levelStats;

    public LevelSettings Settings => _settings;
    public string LevelStats => _levelStats;
    public int Stars => _stars;
    public bool IsLevelEnded => _boxSpawner.GetDestroyedBoxes() == _boxSpawner.GetMaxNumberOfBoxes();
    public bool IsLevelWon => _score >= _minBoxesToCatch;
    public bool IsLevelEndProcessed { get; set; }
    

    public void Awake()
    {
        Time.timeScale = 1;
        FindLevelSettigns();
        levelStarted?.Invoke();
    }

    private void FindLevelSettigns()
    {
        Object[] levelsSettigns = Resources.LoadAll(LevelsFolder, typeof(LevelSettings));
        foreach (LevelSettings levelSettings in levelsSettigns)
        {
            if (levelSettings.IsChosenLevel)
            {
                _settings = levelSettings;
                levelSettings.IsChosenLevel = false;
                break;
            }
        }
    }

    private void Start()
    {
        _minBoxesToCatch = (int)Mathf.Round(_boxSpawner.GetMaxNumberOfBoxes() * _minPercentsCaughtToWin);
    }

    public void Update()
    {
        if(!IsLevelEnded || IsLevelEndProcessed)
        {
            return;
        }

        IsLevelEndProcessed = true;
        GenerateLevelStats();
        if(IsLevelWon)
        {
            PrepareNextLevel();
            levelWon?.Invoke();
            return;
        }
        levelLost?.Invoke();
    }

    private void GenerateLevelStats()
    {
        _levelStats = _score + " out of " + _boxSpawner.GetMaxNumberOfBoxes() + " boxes caught.";
    }

    public void IncrementScore() => _score++;

    public void CountStars()
    {
        if (IsOneStar())
        {
            ActivateStarByIndex(0);
        }

        if (IsTwoStars())
        {
            ActivateStarByIndex(1);
        }

        if (IsThreeStars())
        {
            ActivateStarByIndex(2);
        }
    }

    private bool IsOneStar()
    {
        return _score >= _minBoxesToCatch;
    }

    private bool IsTwoStars()
    {
        return _score >= ((HundredPercent - _minPercentsCaughtToWin) / 2 + _minPercentsCaughtToWin) * _boxSpawner.GetMaxNumberOfBoxes();
    }

    private bool IsThreeStars()
    {
        return _score == _boxSpawner.GetMaxNumberOfBoxes();
    }

    private void ActivateStarByIndex(int starIndex)
    {
        _stars++;
        _starObjects[starIndex].SetActive(true);
    }

    public void PrepareNextLevel()
    {
        Object[] levelsSettigns = Resources.LoadAll(LevelsFolder, typeof(LevelSettings));
        foreach (LevelSettings levelSettings in levelsSettigns)
        {
            if(levelSettings.Number - 1 == _settings.Number)
            {
                levelSettings.IsChosenLevel = true;
            }
        }
    }
}
