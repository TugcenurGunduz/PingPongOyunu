using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public string axisName = "Verical1";//tuş seçimi
    public float moveSpeed = 10;//hız
    public Rigidbody2D rb2;
    public Transform player;
    public float bombSpeed = 10000f;//bomba hızı
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn;
    public Transform ball;
    public Text highScore;
    public Text scoreText;
    int HighScore;

    public int Score { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);//başlangıç değeri 0
        highScore.text = HighScore.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()//rb ile ilgili işlemler
    {
        rb2 = GetComponent<Rigidbody2D>();
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        rb2.velocity = new Vector2(moveAxis, 0);

        if (Input.GetKeyDown(KeyCode.Space))//space tuşuna basıldığında
        {
            var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
            bomb.AddForce(player.up * bombSpeed);//yukarı yönde atış

            if (Score > HighScore)//yeni yüksek değerim
            {
                HighScore = Score;
                highScore.text = HighScore.ToString();
                PlayerPrefs.SetInt("HighScore", HighScore);//kayıt etme
            }
        }
    }
    public void PuanDurumu()
    {
        Score++;
        scoreText.text = Score.ToString();

        if (Score % 5 == 0)//her 5 puanda 
        {
            player.position = new Vector3(player.position.x, player.position.y+1);//1 br yukarı çık
            float distance = ball.position.y - player.position.y; //oyuncu ile top arasındaki mesafe

            if (distance < 2)
            {
                this.transform.position = new Vector3(-0.04f, -5f, 0f);

            }
        }

    }

}
