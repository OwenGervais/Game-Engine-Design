using UnityEngine;
using static FactoryBase;

public class ActualFactory : MonoBehaviour
{
    public enum FactoryType { Object1, Object2 }

    public GameObject obj1;
    public GameObject obj2;

    public FactoryBase.IFactory DoTheThing(FactoryType type, Vector3 position)
    {
        GameObject obj = type switch
        {
            FactoryType.Object1 => Instantiate(obj1, position, Quaternion.identity),
            FactoryType.Object2 => Instantiate(obj2, position, Quaternion.identity),
            _ => throw new System.ArgumentException("Incorrect factory type")

        };

        FactoryBase.IFactory thing = obj.GetComponent<FactoryBase.IFactory>();

        thing.Test1();

        return thing;
    }
}