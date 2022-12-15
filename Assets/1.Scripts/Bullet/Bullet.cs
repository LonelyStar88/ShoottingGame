using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BulletData
{
    public float damage;
    public float speed;
    public float delay;
    public bool isPlayer;
    

    public Transform parent;
    public GameObject prefab;

    public Transform tempParent;

    public Transform posParent;
}

public abstract class Bullet : MonoBehaviour
{
    

    public BulletData bd = new BulletData();

    private List<GameObject> bullets = new List<GameObject>();
    private float time = 0;

    public abstract void Initialize();
    
    public virtual void CreateBullet()
    {
        GameObject obj = Instantiate(bd.prefab, bd.posParent);
        

        if(!bd.isPlayer)
        {
            obj.GetComponent<EnemyParent>().posParentTrans = bd.posParent;
            obj.GetComponent<EnemyParent>().enemyTrans = bd.parent;
        }
        else
        {
            obj.GetComponent<MyBulletCol>().SetDamage(bd.damage);
        }
        obj.transform.SetParent(null);
        bullets.Add(obj);
    }
    public virtual void Fire()
    {
        if (bullets.Count == 0)
            return;

        // �÷��̾��� �Ѿ��� ���
        if(bd.isPlayer)
        {
            foreach (var item in bullets)
            {
                item.transform.Translate(new Vector2(0f, Time.deltaTime * bd.speed));
            }
            RemoveBullet();

        }
        // ������ �Ѿ��� ���
        else
        {
            foreach (var item in bullets)
            {
                item.transform.Translate(new Vector2(0f, Time.deltaTime * (bd.speed * -1)));
            }
            RemoveBullet();
        }
        
    }

    public virtual void RemoveBullet(GameObject bullet = null)
    {
        // �Ѿ��� ������ ������ �� ����
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if(bullet != null)
            {
                if(bullet.Equals(bullets[i]))
                {
                    Destroy(bullets[i]);
                    bullets.RemoveAt(i);
                }
            }
            else if(bullets[i].transform.position.y <= -10f)
            {
                    Destroy(bullets[i]);
                    bullets.RemoveAt(i);
            }
            
        }
    }

    void Update()
    {
        if (bd.delay == 0)
            return;
        time += Time.deltaTime;

        if(time > bd.delay)
        {
            CreateBullet();
            time = 0;
        }
        Fire();
        
    }
}
