using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitPoolChunk : SplitChunk
{
    public bool FireOnTop;
    public const float POOL_CHUNK_VERTICAL_OFFSET = 1.25f;

    private void SyncSuper()
    {
        FactoryOnTop = FireOnTop ? BasicFactories.LavaPoolFactory : BasicFactories.WaterPoolFactory;
        FactoryOnBottom = !FireOnTop ? BasicFactories.LavaPoolFactory : BasicFactories.WaterPoolFactory;
        ChunkVerticalOffset = POOL_CHUNK_VERTICAL_OFFSET;
    }

    public override GameObject InstantiateChunk(GameObject parent, Vector2 offset, float size)
    {
        SyncSuper();
        return InstantiateSplitChunk(parent, offset, size);
    }
}
