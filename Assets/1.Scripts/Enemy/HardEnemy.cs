using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;
    public override void Initialize()
    {
        ed.obj = gameObject;
        ed.curHP = 200f;
        ed.maxHP = 200f;
        ed.speed = 0.2f;
        ed.score = 50;
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
