using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class PPatternType1 : MonoBehaviour, IPPattern
    {
        public void Die() => Destroy(gameObject);
    }
}