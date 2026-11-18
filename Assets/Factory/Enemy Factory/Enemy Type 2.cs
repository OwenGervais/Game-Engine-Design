using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class EnemyType2 : MonoBehaviour, IEnemy
    {
        public void Attack()
        {
            Debug.Log("Enemy Type 2 attacks");
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        public void Die() => Destroy(gameObject);
    }
}