using UnityEngine;

public class OperateFactory : MonoBehaviour
{
    public ActualFactory Factory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Factory.DoTheThing(ActualFactory.FactoryType.Object1, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Factory.DoTheThing(ActualFactory.FactoryType.Object2, transform.position);
        }
    }
}