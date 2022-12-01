using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;
    public int countToSpawn;

    private float time = 0;
    private int spawned = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > spawnRate)
        {
            GameObject enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
            enemy.GetComponent<RedPlagueMover>().vSpeed = Random.Range(0.1f, 1.5f);
            enemy.GetComponent<RedPlagueMover>().maxXOffset = Random.Range(0.1f, 2.5f);

            time = 0;
            spawned++;
            if(spawned > countToSpawn)
            {
                Destroy(gameObject);
            }
                
        }
    }
}
