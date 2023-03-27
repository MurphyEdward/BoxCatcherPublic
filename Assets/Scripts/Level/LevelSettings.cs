using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelSettings : ScriptableObject
{

    [SerializeField] private Sprite _background;
    [SerializeField] private List<BoxBehaviour> _boxesTypesToSpawn;
    [SerializeField] private int _maxNumberOfBoxes;
    [SerializeField] private int _number;
    [SerializeField] private float _spawnDelaySeconds;
    [SerializeField] private int _levelDamageModifier;
    [SerializeField] private int _stunDuration;


    public Sprite Background => _background;
    public List<BoxBehaviour> BoxesTypesToSpawn => _boxesTypesToSpawn;
    public int MaxNumberOfBoxes => _maxNumberOfBoxes;
    public int Number => _number;
    public float SpawnDelaySeconds => _spawnDelaySeconds;
    public int LevelDamageModifier => _levelDamageModifier;
    public int StunDuration => _stunDuration;
    public bool IsChosenLevel { get; set; }

    
}
