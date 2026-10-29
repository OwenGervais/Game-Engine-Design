using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class EnemyType1 : MonoBehaviour, IEnemy
    {
        public void Attack() => Debug.Log("Enemy Type 1 attacks");

        public void Die() => 
    }
}