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

    // Start is called before the first frame update
    void Start()
    {
        esd.type = EnemyType.Easy;
        esd.HP = 10;
        esd.point = Random.Range(0, points.Length - 1);
        esd.score = 10;

        Invoke("SpawnEnemy", 2f);
    }

    void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemys[(int)esd.type], points[esd.point].transform);
        EnemyBullet eb = enemy.transform.GetChild(0).GetComponent<EnemyBullet>();
        eb.SetTempParent(tempParent);
        eb.SetEnemy(enemy.transform);
        enemy.Initialize();
        eb.Initialize();
        enemies.Add(enemy);
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
