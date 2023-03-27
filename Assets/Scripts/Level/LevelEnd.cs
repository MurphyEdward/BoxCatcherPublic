using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    
    [SerializeField] private GameObject _gameoverMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private TextMeshProUGUI _onLoseScoreText;
    [SerializeField] private TextMeshProUGUI _onWinScoreText;
    [SerializeField] private LevelInfo _levelInfo;


    private void OnEnable()
    {
        BoxBodyCollider.RunOutOfHealth += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        BoxBodyCollider.RunOutOfHealth -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        _onLoseScoreText.text = _levelInfo.LevelStats;
        GameStatusChanger.PauseGame();
        _gameoverMenu.SetActive(true);
    }
    public void EnableWinMenu()
    {
        _onWinScoreText.text = _levelInfo.LevelStats;
        GameStatusChanger.PauseGame();
        _winMenu.SetActive(true);
        _levelInfo.CountStars();
        LevelPlayerPrefs.SaveLevelStars(_levelInfo.Settings.Number, _levelInfo.Stars);
    }
}

