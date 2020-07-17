using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.tag == "BALL")
        {
            Destroy(gameObject);//topa çarpan bombayı yok eder
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }

}
