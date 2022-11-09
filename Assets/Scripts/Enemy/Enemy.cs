using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    public static int enemyKillCount;
    public TextMeshProUGUI enemyKillsText;

    protected Transform target;
    protected Rigidbody rb;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Attack();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Attack()
    {
        Vector3 movedir = (target.position - transform.position);
        movedir.y = 0;
        movedir.Normalize();

        rb.velocity = movedir * speed;
        transform.rotation = Quaternion.LookRotation(movedir);
    }

    public void TakeDamage(int damage_)
    {
        health -= damage_;

        if (health <= 0)
        {
            enemyKillCount++;
            Destroy(gameObject);
        }
    }
}
