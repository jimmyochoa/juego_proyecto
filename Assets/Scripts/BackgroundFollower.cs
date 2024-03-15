using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollower : MonoBehaviour
{
    public GameObject player;
    Vector3 pos;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x-transform.position.x > spr.sprite.bounds.size.x)
        {
            pos.x+= 3*spr.sprite.bounds.size.x;
            transform.position = pos;
        }
    }
}
