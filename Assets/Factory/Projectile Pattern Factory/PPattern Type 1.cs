using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class PPatternType1 : MonoBehaviour, IPPattern
    {
        [SerializeField] private float[] _fanSpeeds = { 3f, 6f, 10f };
        [SerializeField] private int _projectilesPerFan = 3;
        [SerializeField] private float _fanArcDegrees = 30f;
        [SerializeField] private float _projectileLifetime = 3f;

        public void Fire(float baseAngleDegrees)
        {
            Vector2 origin = transform.position;

            for (int fan = 0; fan < _fanSpeeds.Length; fan++)
            {
                for (int i = 0; i < _projectilesPerFan; i++)
                {
                    float t = _projectilesPerFan == 1 ? 0.5f : i / (float)(_projectilesPerFan - 1);
                    float angle = baseAngleDegrees - _fanArcDegrees / 2f + t * _fanArcDegrees;

                    Projectile p = ObjectPooler.DequeueObject<Projectile>("Bullet");
                    p.transform.SetPositionAndRotation(origin, Quaternion.Euler(0f, 0f, angle));
                    p.gameObject.SetActive(true);
                    p.Initialize(_fanSpeeds[fan], _projectileLifetime, origin);
                }
            }

            Die();
        }

        public void Die() => Destroy(gameObject);
    }
}