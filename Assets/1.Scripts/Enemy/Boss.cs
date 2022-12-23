using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : Enemy
{
   

    [HideInInspector]
    public Transform firePosTrans;

    [SerializeField]private BossBullet bullet;
    
    
    

    [SerializeField] private Transform partten1;
    public override void Initialize()
    {

        ed.obj = gameObject;
        ed.isBoss = true;
        ed.curHP = 100f;
        ed.maxHP = 100f;
        ed.speed = 2f;
        ed.score = 5000;
        ed.itemObjs = items;
        firePosTrans = transform.GetChild(0).transform;
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.4f);
        InvokeRepeating("BulletCreate", 2f, 1f); // BulleCreate 함수를2초뒤에 5초마다 실행
    }

    void Start()
    {
        Initialize();
        
        InvokeRepeating("BulletCreatePartten", 3f, 0.5f);
    }
    void Update()
    {
        BossMove();
        partten1.Rotate(new Vector3(0f, 0f, Time.deltaTime * 30f));
    }
    public void BulletCreatePartten()
    {
        BossBullet eb = Instantiate(bullet, partten1);
        eb.transform.SetParent(TempParent);
        eb.Initialize();
    }
    public override void BulletCreate()
    {
        BossBullet eb = Instantiate(bullet, firePosTrans);
        eb.SetTempParent(TempParent);
        eb.Initialize();
    }

    public override void Damage(float damage)
    {
        ed.curHP -= damage;

        if (ed.curHP > 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSprite, sprites, 0.1f);
        }
        else
        {
            CancelInvoke("BulletCreatePartten");
        }
        base.Damage(damage);

    }

    public override void DropItem()
    {
        base.DropItem();
    }

    

    public override void SetTempParent(Transform trans)
    {
        base.SetTempParent(trans);
    }

    void BossMove()
    {
        if(transform.position.y >= 2)
        {
            transform.Translate(new Vector2(0f, Time.deltaTime * ed.speed * -1));
        }
        
    }

    void Delete()
    {
        GameController.Instance.stage += 1;
        GameController.Instance.enemyCont.SpawnEnemyStart();
        Destroy(gameObject);
    }
}
   
   


