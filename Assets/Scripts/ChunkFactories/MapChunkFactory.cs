using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapChunkFactory: ScriptableObject
{
    public abstract GameObject InstantiateChunk(GameObject parent, Vector2 offset, float size);
}
