using UnityEngine;

[System.Serializable]
public struct DifficultySettings 
{

    [Header("Player")]
    public bool isCheatsEnabled;
    public float deadeyeGainingMultiplier;

    [Header("Holes")]
    public float minHolesSpawnTime;
    public float maxHolesSpawnTime;

}