using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider))]
public class DamageTaken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Time.timeScale = 0;
            Invoke("Restart", 1);
        }
    }

    void Restart()
    {
        Application.Quit();
    }
}
