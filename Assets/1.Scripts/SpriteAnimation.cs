using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites;
    private SpriteRenderer sr;

    private float spriteDelayTime;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
            return;

        delayTime += Time.deltaTime;
        if(delayTime > spriteDelayTime)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteAnimationIndex];
            spriteAnimationIndex++;
            if (spriteAnimationIndex > sprites.Count - 1)
            {
                spriteAnimationIndex = 0;
            }
        }
    }

    public void SetSprite(List<Sprite> argsprites,float delayTime)
    {
        spriteAnimationIndex = 0;
        sprites = argsprites.ToList();
        spriteDelayTime = delayTime;
    }

    public void SetSprite(Sprite sprite, List<Sprite> argsprites, float delayTime)
    {
        sprites.Clear();
        sr.sprite = sprite;
        StartCoroutine(ReturnSprite(argsprites, delayTime));
    }

    IEnumerator ReturnSprite(List<Sprite> argsprites, float delayTime)
    {
        yield return new WaitForSeconds(0.01f);
        SetSprite(argsprites, delayTime);
    }
}
