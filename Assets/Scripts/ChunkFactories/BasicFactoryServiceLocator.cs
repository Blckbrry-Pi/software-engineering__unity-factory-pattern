using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFactoryServiceLocator : ScriptableObject
{
    public MapChunkFactory LavaPoolFactory;
    public MapChunkFactory WaterPoolFactory;
    public MapChunkFactory PoisonPoolFactory;
    public MapChunkFactory FloorFactory;
}
