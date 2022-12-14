using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float health;
    public Image healthBar;
    public bool hasHealthBar;

    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
        if (hasHealthBar)
        {
            healthBar.fillAmount = health / 100;
        }
    }
     
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            gm.remainingLives -= 1;
            if (gm.remainingLives <= 0)
            {
                gm.EndGame();
            }
            else
            {
                gm.StartCoroutine(gm.RespawnPlayer());
            }
        }
    }
}
