using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public float shotCooldown;
    public GameObject projectilePrefab;
    private float initialCooldown = 3.0f;

    override protected void Start()
    {
        base.Start();
        InvokeRepeating("Attack", initialCooldown, shotCooldown);
        transform.LookAt(Camera.main.transform.position);
    }

    override protected void Update()
    {
        //do nothing
    }

    override protected void Attack()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
