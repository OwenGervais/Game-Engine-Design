using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    private bool isLost = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Projectile"))
        {
            if (!isLost)
            {
                loseText.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                isLost = true;
            }
        }
    }

}
