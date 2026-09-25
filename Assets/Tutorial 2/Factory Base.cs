using UnityEngine;

public class FactoryBase : MonoBehaviour
{
    public interface IFactory
    {
        public void Test1();
        public void Test2();
    }
}
