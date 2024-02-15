using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPoolChunk : SplitChunk
{
    public bool PoisonOnTop;
    public const float POOL_CHUNK_VERTICAL_OFFSET = 1.25f;

    private void SyncSuper()
    {
        FactoryOnTop = PoisonOnTop ? BasicFactories.PoisonPoolFactory : BasicFactories.FloorFactory;
        FactoryOnBottom = !PoisonOnTop ? BasicFactories.PoisonPoolFactory : BasicFactories.FloorFactory;
        ChunkVerticalOffset = POOL_CHUNK_VERTICAL_OFFSET;
    }

    public override GameObject InstantiateChunk(GameObject parent, Vector2 offset, float size)
    {
        SyncSuper();
        return InstantiateSplitChunk(parent, offset, size);
    }
}
