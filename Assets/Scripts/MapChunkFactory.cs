using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MapChunkFactory
{
    public GameObject InstantiateChunk(GameObject parent, Vector2 offset, float size);
}
