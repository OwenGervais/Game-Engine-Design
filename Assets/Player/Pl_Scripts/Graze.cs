using UnityEngine;
using System.Collections;

public class Graze : MonoBehaviour
{
    //private Collider2D col;

    void Awake()
    {
        //col = this.GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            GameController.Instance.CurrentScore += 1;
        }
    }
}
