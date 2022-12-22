using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : Enemy
{
    [SerializeField]
    private GameObject[] items;

    [HideInInspector]
    public Transform firePosTrans;

    [SerializeField]private BossBullet bullet;
    [SerializeField]private Transform TempParent;
    [SerializeField]private HPController hpCont;

    [SerializeField]private List<Sprite> sprites;
    [SerializeField] private Sprite hitSprite;
    [SerializeField] private List<Sprite> ExSprite;

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
        
        InvokeRepeating("BulletCreatePartten", 3f, 0.2f);
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

        if(ed.curHP > 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSprite, sprites, 0.1f);
        }

        if (ed.curHP <= 0)
        {
            ed.curHP = 0;
            //CancelInvoke("BulletCreate");
            GameController.Instance.score += ed.score;
            CancelInvoke("BulletCreate");
            CancelInvoke("BulletCreatePartten");
            DropItem();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteAnimation>().SetSprite(ExSprite, 0.1f, Delete);
            ed.obj = null;

        }

       
        hpCont.SetRenderSize(ed.curHP, ed.maxHP);
    }

    public override void DropItem()
    {
        //int itemIdx = Random.Range(0, items.Length);
        int rand = Random.Range(0, 100);
        int itemIdx = 2;
        if (rand < 100)
        {
            Transform trans = GameObject.Find("Items").transform;
            Instantiate(items[itemIdx], transform).transform.SetParent(trans);
        }
    }

    

    public override void SetTempParent(Transform trans)
    {
        TempParent = trans;
    }

    void BossMove()
    {
        if(transform.position.y >= 2)
        {
            ed.obj.transform.Translate(new Vector2(0f, Time.deltaTime * ed.speed * -1));
        }
        
    }

    void Delete()
    {       
        Destroy(gameObject);
    }
}
   
   


