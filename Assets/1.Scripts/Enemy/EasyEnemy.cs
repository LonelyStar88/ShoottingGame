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
    [SerializeField]
    private HPController hpCont;

    public override void Initialize()
    {
        ed.obj = gameObject;
        ed.curHP = 5f;
        ed.maxHP = 5f;
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

        ed.curHP -= damage;
        

        if (ed.curHP <= 0)
        {
            ed.curHP = 0;
            CancelInvoke("BulletCreate");
            Debug.Log("포인트 획득");
            DropItem();
            Destroy(gameObject);
            ed.obj = null;
        
        }
        hpCont.SetRenderSize(ed.curHP, ed.maxHP);
    }
  

    public override void DropItem()
    {
        int rand = Random.Range(0, 100);
        if (rand < 100)
        {
            Transform trans = GameObject.Find("Items").transform;
            Instantiate(items[Random.Range(0,2)], transform).transform.SetParent(trans);
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
