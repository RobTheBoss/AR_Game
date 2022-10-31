using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    override protected void Start()
    {
        base.Start();
        Attack();
    }
}
