using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;

    public float healCooldown;
    private float healTimer;

    public TextMeshProUGUI healthText;
    public GameObject gameOverCanvas;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        healTimer = healCooldown;
        health = maxHealth;
        healthText.text = "Health: " + health.ToString();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healTimer -= Time.deltaTime;

        if (healTimer <= 0 && health < maxHealth)
        {
            healTimer = healCooldown;
            health++;
            healthText.text = "Health: " + health.ToString();
        }

        if (health <= 0)
        {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            Enemy.enemyKillCount = 0;
        }
        else
            Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            health -= 1;
            healthText.text = "Health: " + health.ToString();
            healTimer = healCooldown;
            anim.SetTrigger("Hurt");
        }
    }
}
