using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChunkFactory : ScriptableObject, MapChunkFactory
{
    public GameObject chunkPrefab;

    public SimpleChunkFactory(GameObject lavaPoolPrefab) {
        chunkPrefab = lavaPoolPrefab;
    }

    public GameObject InstantiateChunk(
        GameObject parent,
        Vector2 offset,
        float size
    ) {
        GameObject instance = Instantiate(
            chunkPrefab,
            offset,
            Quaternion.identity
        );

        instance.transform.parent = parent.transform;


        GameObject middleChild = instance.transform.GetChild(1).gameObject;
        GameObject lastChild = instance.transform.GetChild(2).gameObject;

        SpriteRenderer middleChildSpriteRenderer = middleChild.GetComponent<SpriteRenderer>();
        middleChildSpriteRenderer.size = new Vector2(Mathf.Floor(size), middleChildSpriteRenderer.size.y);

        lastChild.transform.localPosition = lastChild.transform.localPosition + Vector3.right * Mathf.Floor(size - 1);

        return instance;
    }
}
