using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryServiceLocator: MonoBehaviour
{

    private readonly static SingletonBase<FactoryServiceLocator> _instance = new();
    public static FactoryServiceLocator Instance => _instance.Instance;


    public List<MapChunkFactory> Factories;


    void Awake()
    {
        _instance.GetOrInitInstance(this);
    }
}
