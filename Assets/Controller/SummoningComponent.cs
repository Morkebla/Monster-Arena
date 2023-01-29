using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningComponent : MonoBehaviour
{
    [SerializeField] Transform _spawnLocation;
    [SerializeField] Material _monsterMaterial;

    public Transform spawnLocation => _spawnLocation;

    public void SpawnMonster(GameObject monsterPrefab)
    {        
        GameObject spawnedMonster = Instantiate(monsterPrefab, spawnLocation.position, spawnLocation.rotation);

        // Assign the monster to share the same tag as the spawner (this makes it the same team)
        spawnedMonster.tag = tag;

        // Change the monster's material to the team's material
        var renderer = spawnedMonster.GetComponentInChildren<Renderer>();
        if (renderer)
        {
            renderer.sharedMaterial = _monsterMaterial;
        }
    }
}
