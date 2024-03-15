using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite [] mySprites;
    private int index = 0;

    private Rigidbody2D myRigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;
    public GameManager myGameManager;
    void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
        myGameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, playerJumpForce);
        }

        myRigidbody2D.velocity = new Vector2(playerSpeed, myRigidbody2D.velocity.y);
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRutine() {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 12) {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ItemGood")) {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("ItemBad")) {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone")) {
            PlayerDeath();
        }
    }
    void PlayerDeath() {
        //load scene Level2D
        SceneManager.LoadScene("Level2D");
    }
}