using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField]
    private GameObject[] items;

    [HideInInspector]
    public Transform firePosTrans;

    [SerializeField]
    private EnemyBullet bullet;
    [SerializeField]
    private Transform TempParent;
    [SerializeField]
    private HPController hpCont;

    public override void Initialize()
    {
        ed.isBoss = false;
        ed.obj = gameObject;
        ed.curHP = 10f;
        ed.maxHP = 10f;
        ed.speed = 0.5f;
        ed.score = 10;
        ed.itemObjs = items;
        firePosTrans = transform.GetChild(0).transform;
        InvokeRepeating("BulletCreate", 2f, 2f); // BulleCreate 함수를2초뒤에 5초마다 실행
    }
    public override void Move()
    {
        base.Move();
    }

    public override void Damage(float damage)
    {

        ed.curHP -= damage;


        if (ed.curHP <= 0)
        {
            ed.curHP = 0;
            GameController.Instance.score += ed.score;
            CancelInvoke("BulletCreate");

            DropItem();
            Destroy(gameObject);
            ed.obj = null;

        }
        hpCont.SetRenderSize(ed.curHP, ed.maxHP);
    }


    public override void DropItem()
    {
        int itemIdx = Random.Range(0, items.Length);
        int rand = Random.Range(0, 100);
        //itemIdx = 1;
        if (rand < 100)
        {
            Transform trans = GameObject.Find("Items").transform;
            Instantiate(items[itemIdx], transform).transform.SetParent(trans);
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
