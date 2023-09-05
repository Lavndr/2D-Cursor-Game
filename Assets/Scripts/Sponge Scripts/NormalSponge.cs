using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSponge : MonoBehaviour
{   
    public SpriteRenderer spriteRenderer;
    public Sprite normalSponge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScrubOnClick()
    {
        spriteRenderer.sprite = normalSponge;
    }
}
