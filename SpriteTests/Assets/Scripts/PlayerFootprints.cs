using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootprints : MonoBehaviour
{
    public GameObject footprintPrefab;
    public Transform footprintSpot1;
    public Transform footprintSpot2;

    public GameObject stomprintPrefab;

    private bool spawningPrints;

    void OnEnable()
    {
        PlayerListener._playerWalking += StartSpawningPrints;
        PlayerListener._playerStopWalking += StopSpawningPrints;

        PlayerListener._playerJumping += CreateStomprint;
    }
    void OnDisable()
    {
        PlayerListener._playerWalking -= StartSpawningPrints;
        PlayerListener._playerStopWalking -= StopSpawningPrints;

        PlayerListener._playerJumping -= CreateStomprint;
    }

    void StartSpawningPrints()
    {
       if (!spawningPrints)
        StartCoroutine(SpawnPrint(footprintPrefab, (20f / 60f), 2f));
    }

    void StopSpawningPrints()
    {
        StopCoroutine("SpawnPrint");
    }

    void CreateStomprint()
    {
        StartCoroutine(SpawnPrint(stomprintPrefab, (20f / 60f), 4f));

    }

    IEnumerator SpawnPrint(GameObject prefab, float time, float despawnTime)
    {
        spawningPrints = true;
        yield return new WaitForSeconds(time);
        GameObject footprint1;
        footprint1 = Instantiate(prefab, footprintSpot1.position, footprintSpot1.rotation) as GameObject;
        GameObject footprint2;
        footprint2 = Instantiate(prefab, footprintSpot2.position, footprintSpot2.rotation) as GameObject;
        spawningPrints = false;

        Destroy(footprint1, despawnTime);
        Destroy(footprint2, despawnTime);
    }
}
