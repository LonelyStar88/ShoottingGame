using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;
    public override void Initialize()
    {
        ed.obj = gameObject;
        ed.curHP = 10f;
        ed.maxHP = 10f;
        ed.speed = 0.5f;
        ed.score = 10;
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
