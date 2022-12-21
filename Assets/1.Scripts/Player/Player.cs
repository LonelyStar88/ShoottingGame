using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Center = 0,
        Left,
        Right
    }

    private Direction dir = Direction.Center;

    [SerializeField]private List<Sprite> centerSP;
    [SerializeField]private List<Sprite> leftSP;
    [SerializeField]private List<Sprite> rightSP;
    [SerializeField]private SpriteRenderer sr;
    [SerializeField]private GameObject[] lifeObjs;
    [SerializeField]private GameObject[] Booms;

    private float damage = 1f;
    private float speed = 3f;
    private int nowbooms = 0;
    [SerializeField]private Transform parent;
    [SerializeField]private MyBullet bullet;
    private List<MyBullet> myBullets = new List<MyBullet>();
    // Start is called before the first frame update
    void Start()
    {
        nowbooms = GameController.Instance.boom;
        for (int i = 0; i < Booms.Length; i++)
        {
            Booms[i].SetActive(false);
        }
        for(int i = 0; i < nowbooms; i++)
        {
            Booms[i].SetActive(true);
        }
        for(int i = 0; i< 10; i++)
        {
            myBullets.Add(Resources.Load<MyBullet>($"PlayerBullet/PlayerBullet {i+1}"));
        }
        bullet = myBullets[0];

        dir = Direction.Center;
        GetComponent<SpriteAnimation>().SetSprite(centerSP, 0.2f);
        InvokeRepeating("CreateBullet", 0.5f, 0.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.playtype != GamePlayType.Play)
            return;
        // ĳ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float ClampX = Mathf.Clamp(transform.position.x + x, -3.4f, 3.4f);
        
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float ClampY = Mathf.Clamp(transform.position.y + y, -4f, 4f);
        
        transform.position = new Vector3(ClampX, ClampY, 0);
        //transform.position += new Vector3(ClampY, -4f, 3f);

        if(x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            GetComponent<SpriteAnimation>().SetSprite(leftSP, 0.2f);
        }
        else if(x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            GetComponent<SpriteAnimation>().SetSprite(rightSP, 0.2f);
        }
        else if(x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            GetComponent<SpriteAnimation>().SetSprite(centerSP, 0.2f);
        }
        
    }
    public void CreateBullet()
    {
        MyBullet pb = Instantiate(bullet, transform);
        pb.transform.localPosition = new Vector2(0f, 1f); //localPosition �� źȯ �ڽ��� �������� �ǹ��Ѵ�.
        pb.SetTempParent(parent);
        pb.Damage = damage;
        pb.Initialize();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<Enemy>().Damage(10000);
        }
        else if(collision.tag.Equals("Coin"))
        {
            GameController.Instance.score += 100;
            Destroy(collision.gameObject);
        }
        else if(collision.tag.Equals("Power"))
        {
            GameController.Instance.power++;
            bullet = myBullets[(int)GameController.Instance.power - 1];
            Destroy(collision.gameObject);
        }
        else if(collision.tag.Equals("boom"))
        {
            GameController.Instance.boom++;
            Destroy(collision.gameObject);
        }
        else if(collision.tag.Equals("SubPlayer"))
        {

        }
    }
    public void Die()
    {
        CancelInvoke("CreateBullet");
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;

        GameController.Instance.Iife--;

        if(GameController.Instance.Iife >= 0)
        {
            lifeObjs[GameController.Instance.Iife].SetActive(false);
        }
        StartCoroutine(ReLife());
        if (GameController.Instance.Iife < 0)
        {
            GameController.Instance.playtype = GamePlayType.Stop;
        }
        //gameObject.SetActive(false);
    }

    IEnumerator ReLife()
    {
        bool show = false;
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().enabled = !show;
            show = !show;
            yield return new WaitForSeconds(0.1f);
            
        }
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        InvokeRepeating("CreateBullet", 0f, 0.3f);
    }
}
