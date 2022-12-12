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

    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        dir = Direction.Center;
        GetComponent<SpriteAnimation>().SetSprite(centerSP, 0.2f);
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
}
