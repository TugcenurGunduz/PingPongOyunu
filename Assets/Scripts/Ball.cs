using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    Rigidbody2D rb2;
    public Player Player;
    public float moveSpeed=10;//topun hızı

    // Start is called before the first frame update
   void Start()
    {
        Invoke("ballMotion", 2f);//oyun başladıktan 2 sn sonra top hareket etsin
    }
    
    public void ballMotion()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1, 0) * moveSpeed;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();//ses

        if (collision.gameObject.tag == "BOMBA")
        {
            Player.PuanDurumu();
        }
    }

}
