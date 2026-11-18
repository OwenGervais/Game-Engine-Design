using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class EnemyType3 : MonoBehaviour, IEnemy
    {
        public void Attack()
        {
            Debug.Log("Enemy Type 3 attacks");
            ProjectileFactory.Instance.CreatePPattern(PPatternType.PPattern1, transform.position, -90f);
        }

        public void Die() => Destroy(gameObject);
    }
}