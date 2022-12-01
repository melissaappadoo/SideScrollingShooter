using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    void Start()
    {
        /*if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>;
        }*/
    }

    public Transform playerPrefab;
    public Transform spawnPoint;

    public void RespawnPlayer ()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
