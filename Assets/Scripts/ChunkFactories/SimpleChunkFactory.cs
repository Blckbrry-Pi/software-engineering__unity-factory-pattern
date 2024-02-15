using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChunkFactory : MapChunkFactory
{
    public GameObject chunkPrefab;

    public SimpleChunkFactory(GameObject lavaPoolPrefab) {
        chunkPrefab = lavaPoolPrefab;
    }

    public override GameObject InstantiateChunk(
        GameObject parent,
        Vector2 offset,
        float size
    ) {
        float middleSize = Mathf.Max(size - 2, 1);

        GameObject instance = Instantiate(
            chunkPrefab,
            offset,
            Quaternion.identity
        );

        instance.transform.parent = parent.transform;


        GameObject middleChild = instance.transform.GetChild(1).gameObject;
        GameObject lastChild = instance.transform.GetChild(2).gameObject;

        SpriteRenderer middleChildSpriteRenderer = middleChild.GetComponent<SpriteRenderer>();
        middleChildSpriteRenderer.size = new Vector2(Mathf.Floor(middleSize), middleChildSpriteRenderer.size.y);

        lastChild.transform.localPosition += Vector3.right * Mathf.Floor(middleSize - 1);

        return instance;
    }
}
