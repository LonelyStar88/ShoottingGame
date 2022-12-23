using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public GameObject obj;

    public bool isBoss;
    public float speed;
    public float curHP;
    public float maxHP;

    public int score;

    public GameObject[] itemObjs;

}
public abstract class Enemy : MonoBehaviour
{

    public EnemyData ed = new EnemyData();
    public GameObject[] items;
    public HPController hpCont;
    public List<Sprite> sprites;
    public List<Sprite> ExSprite;
    public Sprite hitSprite;
    public Transform TempParent;
    public abstract void Initialize();

    public abstract void BulletCreate();

    public virtual void DropItem()
    {
        int rand = Random.Range(0, 100);
        int itemIdx = Random.Range(0, items.Length);
        if (rand < 100)
        {
            Transform trans = GameObject.Find("Items").transform;
            Instantiate(items[itemIdx], transform).transform.SetParent(trans);
        }
    }
    public virtual void SetTempParent(Transform trans)
    {
        TempParent = trans;
    }

    public virtual void Move()
    {
        if (ed.isBoss)
            return;

        if (ed.speed == 0)
            return;

        if (ed.obj == null)
            return;

        ed.obj.transform.Translate(new Vector2(0f, Time.deltaTime * ed.speed * -1));

        if (ed.obj.transform.position.y <= -16)
        {
            Delete();
        }
    }

    public virtual void Damage(float damage)
    {
        ed.curHP -= damage;

        if (ed.curHP > 0)
        {
            GetComponent<SpriteAnimation>().SetSprite(hitSprite, sprites, 0.1f);
        }
        else
        {
            ed.curHP = 0;
            GameController.Instance.Score += ed.score;
            CancelInvoke("BulletCreate");

            DropItem();
            Destroy(gameObject);
            ed.obj = null;

        }
        hpCont.SetRenderSize(ed.curHP, ed.maxHP);
    }

   

    void Delete()
    {
        Destroy(ed.obj);
        ed.obj = null;
    }
    
    
}
