using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        myRigidbody2D.velocity = new Vector2(bulletSpeed, myRigidbody2D.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemBad")
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
