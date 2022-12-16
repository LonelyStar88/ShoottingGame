using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;

    [HideInInspector]
    public Transform firePosTrans;

    [SerializeField]
    private EnemyBullet bullet;
    [SerializeField]
    private Transform TempParent;

    public override void Initialize()
    {
        ed.obj = gameObject;
        ed.curHP = 1f;
        ed.maxHP = 1f;
        ed.speed = 1f;
        ed.score = 1;
        ed.itemObjs = items;
        firePosTrans = transform.GetChild(0).transform;

        InvokeRepeating("BulletCreate", 2f, 5f); // BulleCreate 함수를2초뒤에 5초마다 실행
    }

    
    public override void Move()
    {
        base.Move();
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);

        if(ed.curHP <= 0)
        {
            CancelInvoke("BulletCreate");
        }
    }

    public override void BulletCreate()
    {

        EnemyBullet eb = Instantiate(bullet, firePosTrans);
        eb.SetTempParent(TempParent);
        eb.Initialize();
    }

    public override void SetTempParent(Transform trans)
    {
        TempParent = trans;
    }

   
}
