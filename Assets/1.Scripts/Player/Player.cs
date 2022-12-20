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
    [SerializeField] private GameObject[] lifeObjs;

    private float damage = 1f;
    private float speed = 3f;
    [SerializeField]private Transform parent;
    [SerializeField]private MyBullet bullet;
    private List<MyBullet> myBullets = new List<MyBullet>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< 10; i++)
        {
            myBullets.Add(Resources.Load<MyBullet>($"PlayerBullet/PlayerBullet {i+1}"));
        }
        bullet = myBullets[0];

        dir = Direction.Center;
        GetComponent<SpriteAnimation>().SetSprite(centerSP, 0.2f);
        InvokeRepeating("CreateBullet", 0.5f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.playtype != GamePlayType.Play)
            return;
        // 캐릭터 이동 범위 지정
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float ClampX = Mathf.Clamp(transform.position.x + x, -2, 2);
        
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float ClampY = Mathf.Clamp(transform.position.y + y, -4, 3);
        
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
        pb.transform.localPosition = new Vector2(0f, 1f); //localPosition 은 탄환 자신의 포지션을 의미한다.
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
        else if(collision.tag.Equals("SubPlayer"))
        {

        }
    }
    public void Die()
    {
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
    }
}
