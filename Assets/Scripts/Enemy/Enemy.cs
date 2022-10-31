using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    public float speed;
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
    }
}