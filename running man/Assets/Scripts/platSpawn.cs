using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platSpawn : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200F;

    [SerializeField] private Transform levelPart_start;
    [SerializeField] private Transform levelPart_1;
   

    private Vector3 lastEndPosition;


    private void Update()
    {
        
    }
    private void Awake()
    {
        lastEndPosition = levelPart_start.Find("EndPosition").position;
        SpawnLevelPart();
        SpawnLevelPart();

    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }






}
