using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Easy,
    Normal,
    Hard,
    Boss
}

public struct EnemySpawnData
{
    public EnemyType type;
    public int point;
    public int HP;
    public int score;
}

public class EnemyController : MonoBehaviour
{
    EnemySpawnData esd = new EnemySpawnData();

    [SerializeField]
    private Enemy[] enemys;
    [SerializeField]
    private GameObject[] points;
    [SerializeField]
    private Transform tempParent;

    private List<Enemy> enemies = new List<Enemy>();
    private int temp = 0;
    private int count = 0;

    //private int temppointidx = 0;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 100);
        if (rand < 90)
        {
            esd.type = EnemyType.Easy;
            esd.HP = 10;
            esd.point = Random.Range(0, points.Length - 1);
            esd.score = 10;
        }
        else if(rand < 95)
        {
            esd.type = EnemyType.Normal;
            esd.HP = 20;
            esd.point = Random.Range(0, points.Length - 1);
            esd.score = 50;
        }
        else
        {
            esd.type = EnemyType.Hard;
            esd.HP = 50;
            esd.point = Random.Range(0, points.Length - 1);
            esd.score = 200;
        }
        temp = (int)esd.type;
            esd.HP = 10;
            esd.point = Random.Range(0, points.Length - 1);
            esd.score = 10;
        
        InvokeRepeating("SpawnEnemy", 0.5f, 1f);
    }

    void changetype()
    {
        int rand = Random.Range(0, 100);
        if (rand < 60)
        {
            esd.type = EnemyType.Easy;
        }
        else if (rand < 90)
        {
            esd.type = EnemyType.Normal;
        }
        else
        {
            esd.type = EnemyType.Hard;
        }
    }
    
    void SpawnEnemy()
    {
        if(count >0)
        {
            changetype();
        }
        
        Enemy enemy = Instantiate(enemys[(int)esd.type], points[Random.Range(0, points.Length - 1)].transform);
        enemy.Initialize();
        enemy.SetTempParent(tempParent);
        enemies.Add(enemy);
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0)
            return;

        foreach(var item in enemies)
        {
            item.Move();
           
        }

        
   
    }
}
