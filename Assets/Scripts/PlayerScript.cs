using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool jumpState = false;
    private Rigidbody2D rigid2d;
    private SpriteRenderer spriteSetting;
    bool isPlayerBig = false;

    bool isGrounded = false; //

    public GameObject ground;
    public MasterScript masterScript;
    public AudioClip jumpSound;






    void Start()
    {
        anim = GetComponent<Animator>();
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.mass = 1.5f;
        rigid2d.gravityScale = 2.0f;
        spriteSetting = GetComponent<SpriteRenderer>();
        ground.GetComponent<Collider2D>().isTrigger = false;

    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_run") || anim.GetCurrentAnimatorStateInfo(0).IsName("player_jump"))
            {
                jumpState = true;
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);

            }

        }

    }
    void FixedUpdate()
    {
        if (jumpState)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_run") || anim.GetCurrentAnimatorStateInfo(0).IsName("player_jump"))
            {
                jumpState = false;
                anim.SetTrigger("jumpTrigger");
                rigid2d.isKinematic = true;
                rigid2d.isKinematic = false;
                rigid2d.AddForce(new Vector2(0f, 700.0f));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bronze"))
        {
            Destroy(collision.gameObject);
            masterScript.score += 120;
        }
        if (collision.gameObject.CompareTag("Silver"))
        {
            Destroy(collision.gameObject);
            masterScript.score += 150;
        }
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            masterScript.score += 180;
        }


        if (collision.gameObject.CompareTag("Spike") && !isPlayerBig)
        {
            Destroy(collision.gameObject);
            ground.GetComponent<Collider2D>().isTrigger = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;


            anim.SetTrigger("dieTrigger");
            masterScript.isPlayerDie = true;
        }
        if (collision.gameObject.CompareTag("Apple") && !isPlayerBig)
        {
            Destroy(collision.gameObject);
            StartCoroutine(playerBigEffect());
        }
        if (collision.gameObject.CompareTag("Spikefloor") && !isPlayerBig)
        {
            Destroy(collision.gameObject);
            ground.GetComponent<Collider2D>().isTrigger = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;

            anim.SetTrigger("dieTrigger");
            masterScript.isPlayerDie = true;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;  
            }
        }
    }




    IEnumerator playerBigEffect()  //무적모드
    {
        isPlayerBig = true;
        transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);  //3 수정(원래 4)
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < 3; i++)
        {
            spriteSetting.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.3f);
            spriteSetting.color = new Color(1, 1, 1, 1.0f);
            yield return new WaitForSeconds(1.3f);
        }
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);  //1로 수정
        yield return new WaitForSeconds(0.3f);
        isPlayerBig = false;
    }

}


