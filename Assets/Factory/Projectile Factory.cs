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
        [SerializeField] private GameObject _pPatternType1;
        [SerializeField] private GameObject _pPatternType2;

        public IPPattern CreatePPattern(PPatternType type, Vector3 position)
        {
            GameObject prefab = type switch
            {
                PPatternType.PPattern1 => _pPatternType1,
                PPatternType.PPattern2 => _pPatternType2,
                _ => throw new System.ArgumentException($"Unknown type: {type}")
            };

            var instance = Instantiate(prefab, position, Quaternion.identity);
            return instance.GetComponent<IPPattern>();
        }
    }
}