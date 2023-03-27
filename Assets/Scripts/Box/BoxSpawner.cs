using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    private const float _spawnBordersX = 8.0f;
    private const float _spawnHeightY = 9.0f;
    private const float _minimumSpawnDelay = 1.0f;

    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private List<BoxBehaviour> _boxesTypesToSpawn;
    [SerializeField] private int _maxNumberOfBoxes;
    [SerializeField] private int _levelDamageModifier;
    [SerializeField] private float _spawnDelaySeconds;
    private float _boxesDestroyed;
    
    public int GetMaxNumberOfBoxes()
    {
        return _maxNumberOfBoxes;
    }

    public void SetMaxNumberOfBoxes(int number)
    {
        _maxNumberOfBoxes = number;
    }

    public float GetDestroyedBoxes()
    {       
        return _boxesDestroyed;
    }

    public void AddBoxDestroyed()
    {
        Debug.Log("Boxes before destroy: " + _boxesDestroyed);
        Debug.Log("box was destroyed");
        _boxesDestroyed++;
        Debug.Log("boxes after destroy: " + _boxesDestroyed);
    }

    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    public void AssignBoxesSpawnSettings()
    { 
        if(_levelInfo.Settings == null) 
        {
            return;
        }

        _boxesTypesToSpawn = _levelInfo.Settings.BoxesTypesToSpawn;
        _maxNumberOfBoxes = _levelInfo.Settings.MaxNumberOfBoxes;
        _levelDamageModifier = _levelInfo.Settings.LevelDamageModifier;
        SetSpawnDelay(_levelInfo.Settings.SpawnDelaySeconds);
    }

    public void SetSpawnDelay(float spawnDelay)
    {
        if (spawnDelay < _minimumSpawnDelay)
        {
            throw new System.ArgumentOutOfRangeException("Input should be more than " + _minimumSpawnDelay);
        }

        _spawnDelaySeconds = spawnDelay;
    }

    IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelaySeconds);
            SpawnRandomBox();
        }
    }

    private void SpawnRandomBox()
    {
        
        
        int randomBoxTypeIndex = Random.Range(0, _boxesTypesToSpawn.Count);
        GameObject randomBox = _boxesTypesToSpawn[randomBoxTypeIndex].gameObject;
        Quaternion randomRotation = Quaternion.Euler(randomBox.transform.rotation.x, randomBox.transform.rotation.y, Random.Range(0, 360));
        Vector3 randomPosition = new Vector3(Random.Range(-_spawnBordersX, _spawnBordersX), _spawnHeightY, 0);

        Instantiate(randomBox, randomPosition, randomRotation);
        
    }
}
