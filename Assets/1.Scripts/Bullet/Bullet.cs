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
}

public abstract class Bullet : MonoBehaviour
{
    

    public BulletData bd = new BulletData();

    private List<GameObject> bullets = new List<GameObject>();
    private float time = 0;

    public abstract void Initialize();
    
    public virtual void CreateBullet()
    {
        GameObject obj = Instantiate(bd.prefab, bd.parent);
        obj.transform.SetParent(null);
        bullets.Add(obj);
    }
    public virtual void Fire()
    {
        if (bullets.Count == 0)
            return;

        // 플레이어의 총알일 경우
        if(bd.isPlayer)
        {
            foreach (var item in bullets)
            {
                item.transform.Translate(new Vector2(0f, Time.deltaTime * bd.speed));
            }
            RemoveBullet();

        }
        // 적들의 총알일 경우
        else
        {
            foreach (var item in bullets)
            {
                item.transform.Translate(new Vector2(0f, Time.deltaTime * (bd.speed * -1)));
            }
            RemoveBullet();
        }
        
    }

    void RemoveBullet()
    {
        // 총알이 밖으로 나갔을 시 삭제
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets[i].transform.position.y <= -10f)
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
