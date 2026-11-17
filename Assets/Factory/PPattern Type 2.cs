using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class PPatternType2 : MonoBehaviour, IPPattern
    {
        public void Die() => Destroy(gameObject);
    }
}