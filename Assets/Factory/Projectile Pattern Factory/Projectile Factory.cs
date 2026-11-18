using UnityEngine;

namespace Patterns.Creational.Factory
{
    public enum PPatternType
    {
        PPattern1,
        PPattern2
    }

    public class ProjectileFactory : MonoBehaviour
    {
        public static ProjectileFactory Instance { get; private set; }

        [SerializeField] private GameObject _pPatternType1;
        [SerializeField] private GameObject _pPatternType2;

        [SerializeField] private Projectile _bulletPrefab;
        [SerializeField] private int _bulletPoolSize = 100;

        private void Awake()
        {
            Instance = this;

            if (!ObjectPooler.poolDictionary.ContainsKey("Bullet"))
                ObjectPooler.SetupPool(_bulletPrefab, _bulletPoolSize, "Bullet");
        }

        public IPPattern CreatePPattern(PPatternType type, Vector3 position, float baseAngleDegrees = 0f)
        {
            GameObject prefab = type switch
            {
                PPatternType.PPattern1 => _pPatternType1,
                PPatternType.PPattern2 => _pPatternType2,
                _ => throw new System.ArgumentException($"Unknown type: {type}")
            };

            var instance = Instantiate(prefab, position, Quaternion.identity);
            var pattern = instance.GetComponent<IPPattern>();
            pattern.Fire(baseAngleDegrees);
            return pattern;
        }
    }
}