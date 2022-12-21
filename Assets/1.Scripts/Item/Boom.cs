using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item
{
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();

    public override void Initialize()
    {
        itemData.obj = gameObject;
        itemData.speed = 3f;
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.2f);
        Initialize();
    }
}
