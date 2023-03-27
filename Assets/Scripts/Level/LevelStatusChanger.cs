using UnityEngine;
using UnityEngine.UI;

public class LevelStatusChanger : MonoBehaviour
{
    private void Start()
    {
        ProcessLevelsStatus();
    }

    private void ProcessLevelsStatus()
    {
        for (int levelIndex = 1; levelIndex < transform.childCount; levelIndex++)
        {
            Level previousLevel = transform.GetChild(levelIndex - 1).GetComponent<Level>();

            if (IsLevelPassed(previousLevel)) continue;

            DeactivateLevel(levelIndex);

        }
    }

    private bool IsLevelPassed(Level level)
    {
        return level.Stars > 0;
    }

    private void DeactivateLevel(int levelIndex)
    {
        Button levelButton = transform.GetChild(levelIndex).GetComponent<Button>();
        levelButton.interactable = false;
    }
}
