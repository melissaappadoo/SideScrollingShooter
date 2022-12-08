using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer ()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
