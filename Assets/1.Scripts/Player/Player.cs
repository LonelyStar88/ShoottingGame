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

    [SerializeField]
    private List<Sprite> centerSP;
    [SerializeField]
    private List<Sprite> leftSP;
    [SerializeField]
    private List<Sprite> rightSP;
    [SerializeField]
    private SpriteRenderer sr;

    private float damage = 1f;
    private float speed = 3f;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private MyBullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        dir = Direction.Center;
        GetComponent<SpriteAnimation>().SetSprite(centerSP, 0.2f);
        //InvokeRepeating("CreateBullet", 0.5f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float ClampX = Mathf.Clamp(transform.position.x + x, -2, 2);
        transform.position = new Vector3(ClampX, -4f, 0f);

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
        pb.SetDamage(damage);
        pb.Initialize();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            
            collision.GetComponent<Enemy>().Damage(10000);
            //return;
            //Destroy(gameObject);
        }
    }
    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(ReLife());
        //gameObject.SetActive(false);
    }

    IEnumerator ReLife()
    {
        bool show = false;
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().enabled = !show;
            yield return new WaitForSeconds(1f);
            GetComponent<SpriteRenderer>().enabled = show;
        }
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
