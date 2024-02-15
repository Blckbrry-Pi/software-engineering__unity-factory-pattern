using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SplitChunk : SuperChunkFactory
{
    protected MapChunkFactory FactoryOnTop;
    protected MapChunkFactory FactoryOnBottom;

    protected float ChunkVerticalOffset = 1.5f;

    public GameObject InstantiateSplitChunk(GameObject parent, Vector2 offset, float size)
    {
        size = Mathf.Ceil(size / 8) * 8;
        float lrChunkSize = Mathf.Ceil(size / 4);
        float middleChunkSize = Mathf.Ceil(size * 3 / 8);

        GameObject chunk = new GameObject(this.GetType().Name + " @ (" + offset.x + ", " + offset.y + ")");

        Vector2 leftOffset = new(0, 0);
        Vector2 rightOffset = new(size * 3 / 4, 0);
        Vector2 middleOffset = new(size * 5 / 16, 0);

        Vector2 upperOffset = middleOffset + new Vector2(0, ChunkVerticalOffset);
        Vector2 lowerOffset = middleOffset - new Vector2(0, ChunkVerticalOffset);

        GameObject leftFloor = BasicFactories.FloorFactory.InstantiateChunk(chunk, leftOffset, lrChunkSize);
        GameObject rightFloor = BasicFactories.FloorFactory.InstantiateChunk(chunk, rightOffset, lrChunkSize);

        GameObject middleFire = FactoryOnTop.InstantiateChunk(chunk, upperOffset, middleChunkSize);
        GameObject middleWater = FactoryOnBottom.InstantiateChunk(chunk, lowerOffset, middleChunkSize);
        
        
        leftFloor.transform.parent = chunk.transform;
        rightFloor.transform.parent = chunk.transform;
        middleFire.transform.parent = chunk.transform;
        middleWater.transform.parent = chunk.transform;

        chunk.transform.position = new Vector3(offset.x, offset.y, 0);

        return chunk;
    }
}
