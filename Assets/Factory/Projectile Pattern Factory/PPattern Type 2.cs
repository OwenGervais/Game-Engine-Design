using UnityEngine;

namespace Patterns.Creational.Factory
{
    public class PPatternType2 : MonoBehaviour, IPPattern
    {
        public void Fire(float baseAngleDegrees)
        { 
            Debug.Log("PPattern 2 fired");
        }

        public void Die() => Destroy(gameObject);
    }
}