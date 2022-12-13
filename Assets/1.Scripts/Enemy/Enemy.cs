using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public GameObject obj;

    public float speed;
    public float curHP;
    public float maxHP;

    public int score;

    public GameObject[] itemObjs;

}
public abstract class Enemy : MonoBehaviour
{
    public EnemyData ed = new EnemyData();
    public abstract void Initialize();

    public virtual void Move()
    {
        if (ed.speed == 0)
            return;

        ed.obj.transform.Translate(new Vector2(0f, Time.deltaTime * ed.speed * -1));

        if (ed.obj.transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }
    
    
    public virtual void Damage(float damage)
    {
        ed.curHP -= damage;

        if(ed.curHP <= 0)
        {
            Debug.Log("Æ÷ÀÎÆ® È¹µæ");
            Destroy(ed.obj);
        }
    }

    
    
}
