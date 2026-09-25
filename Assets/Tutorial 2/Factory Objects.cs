using UnityEngine;
public class Object1 : FactoryBase, FactoryBase.IFactory
{
    public void Test1() => Debug.Log("Test 1");
    public void Test2() => Debug.Log("Test 2");
}

public class Object2 : FactoryBase, FactoryBase.IFactory
{
    public void Test1() => Debug.Log("Test 1");
    public void Test2() => Debug.Log("Test 2");
}