using UnityEngine;

namespace Patterns.Creational.Factory
{
    public enum EnemyType
    {
        Enemy1,
        Enemy2,
        Enemy3
    }

    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyType1;
        [SerializeField] private GameObject _enemyType2;
        [SerializeField] private GameObject _enemyType3;

        public IEnemy CreateEnemy(EnemyType type, Vector3 position)
        {
            GameObject prefab = type switch
            {
                EnemyType.Enemy1 => _enemyType1,
                EnemyType.Enemy2 => _enemyType2,
                EnemyType.Enemy3 => _enemyType3,
                _ => throw new System.ArgumentException($"Unknown type: {type}")
            };

            var instance = Instantiate(prefab, position, Quaternion.identity);
            return instance.GetComponent<IEnemy>();
        }
    }
}