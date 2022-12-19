using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private Transform TempParent;
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
    public override void BulletCreate()
    {
        throw new System.NotImplementedException();
    }

    public override void DropItem()
    {
        throw new System.NotImplementedException();
    }
    public override void SetTempParent(Transform trans)
    {
        TempParent = trans;
    }
    public override void Damage(float damage)
    {
        ed.curHP -= damage;

        if (ed.curHP <= 0)
        {
            //CancelInvoke("BulletCreate");
            Debug.Log("����Ʈ ȹ��");
            Destroy(gameObject);
            ed.obj = null;

        }
    }
}
