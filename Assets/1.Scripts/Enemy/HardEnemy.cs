using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    

    [HideInInspector]
    public Transform firePosTrans;

    [SerializeField]
    private EnemyBullet bullet;
    
    
   
    public override void Initialize()
    {
        ed.isBoss = false;
        ed.obj = gameObject;
        ed.curHP = 50f;
        ed.maxHP = 50f;
        ed.speed = 0.2f;
        ed.score = 50;
        ed.itemObjs = items;
        firePosTrans = transform.GetChild(0).transform;
        InvokeRepeating("BulletCreate", 2f, 1f); // BulleCreate 함수를2초뒤에 5초마다 실행
    }
    public override void Move()
    {
        base.Move();
    }

    public override void BulletCreate()
    {
        EnemyBullet eb = Instantiate(bullet, firePosTrans);
        eb.SetTempParent(TempParent);
        eb.Initialize();
    }

    public override void DropItem()
    {
        base.DropItem();
    }

    public override void SetTempParent(Transform trans)
    {
        base.SetTempParent(trans);
    }

    public override void Damage(float damage)
    {
        ed.curHP -= damage;

        if (ed.curHP > 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSprite, sprites, 0.1f);
        }
        base.Damage(damage);
    }
}
