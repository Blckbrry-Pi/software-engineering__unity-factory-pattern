using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LittlePoolChunk : SuperChunkFactory
{
    public enum PoolType
    {
        Fire,
        Water,
        Poison
    }

    public PoolType ChosenPoolType;

    private MapChunkFactory GetPoolFactory() {
        return ChosenPoolType switch
        {
            PoolType.Fire => BasicFactories.LavaPoolFactory,
            PoolType.Water => BasicFactories.WaterPoolFactory,
            PoolType.Poison => BasicFactories.PoisonPoolFactory,
            _ => BasicFactories.WaterPoolFactory,
        };
    }

    public override GameObject InstantiateChunk(GameObject parent, Vector2 offset, float size)
    {
        size = Mathf.Ceil(size / 8) * 8;

        float poolSize = Mathf.Min(size * 3 / 8, 5f);
        float floorSize = Mathf.Ceil((size - poolSize) / 2);

        Vector2 leftOffset = new(0, 0);
        Vector2 poolOffset = new(floorSize - 0.5f, 0);
        Vector2 rightOffset = new(size - floorSize, 0);

        GameObject chunk = new(GetType().Name + " @ (" + offset.x + ", " + offset.y + ")");


        GameObject leftFloor = BasicFactories.FloorFactory.InstantiateChunk(chunk, leftOffset, floorSize);
        GameObject rightFloor = BasicFactories.FloorFactory.InstantiateChunk(chunk, rightOffset, floorSize);

        GameObject pool = GetPoolFactory().InstantiateChunk(chunk, poolOffset, poolSize);
        
        leftFloor.AddComponent<SortingGroup>().sortingLayerName = "MapBack";
        rightFloor.AddComponent<SortingGroup>().sortingLayerName = "MapBack";
        pool.AddComponent<SortingGroup>().sortingLayerName = "MapFront";
        
        leftFloor.transform.parent = chunk.transform;
        rightFloor.transform.parent = chunk.transform;
        pool.transform.parent = chunk.transform;

        chunk.transform.position = new(offset.x, offset.y, 0);

        return chunk;
    }
}
