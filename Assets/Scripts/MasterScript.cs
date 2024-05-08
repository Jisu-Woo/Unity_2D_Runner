using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    [HideInInspector]
    public float score;
    [HideInInspector]
    public bool isPlayerDie = false;
    public Image gameOver;
    public Image gameOver1;
    public Image gameOver2;
    public Image gameOver3;
    public Image gameOver4;

    public Button back;
    public Button restart;
    public Text scoreUI;




    private void Start()
    {
        score = 0;

        if(!isPlayerDie)
        {
            InvokeRepeating("GetScore", 1.0f, 1.0f);  //초당 10점씩 점수 증가

        }
    }

    private void GetScore()
    {
        score += 10.0f;  //10씩 증가
        scoreText.text = score.ToString();
        scoreUI.text = score.ToString();

    }


    private void Update()
    {
        if (isPlayerDie)
        {
            CancelInvoke("GetScore");

            gameOver.gameObject.SetActive(true);
            back.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            gameOver1.gameObject.SetActive(true);
            gameOver2.gameObject.SetActive(true);
            gameOver3.gameObject.SetActive(true);
            gameOver4.gameObject.SetActive(true);
            scoreUI.gameObject.SetActive(true);



        }
    }


}
