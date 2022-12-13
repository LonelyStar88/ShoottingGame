using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;
    public override void Initialize()
    {
        ed.obj = gameObject;
        ed.curHP = 1f;
        ed.maxHP = 1f;
        ed.speed = 1f;
        ed.score = 1;
        ed.itemObjs = items;
    }
    public override void Move()
    {
        base.Move();
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
    }
}
