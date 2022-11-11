using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    private Animator anim;
    //public float shotCooldown;
    //private float initialCooldown = 3.0f;

    override protected void Start()
    {
        base.Start();
        transform.LookAt(Camera.main.transform.position);
        anim = GetComponent<Animator>();
    }

    override protected void Update()
    {
        //do nothing
    }

    override protected void Attack()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
    }

    override public void TakeDamage(int damage_)
    {
        base.TakeDamage(damage_);
        anim.SetTrigger("Hit");
    }
}
