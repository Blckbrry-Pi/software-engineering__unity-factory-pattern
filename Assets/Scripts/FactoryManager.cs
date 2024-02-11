using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager: MonoBehaviour
{
    public SimpleChunkFactory LavaPoolFactory;
    public SimpleChunkFactory WaterPoolFactory;
    public SimpleChunkFactory PoisonPoolFactory;
    public SimpleChunkFactory FloorFactory;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeLavaPool(Vector2 worldCoords, float size)
    {
        LavaPoolFactory.InstantiateChunk(gameObject, worldCoords, size);
    }
    public void MakeWaterPool(Vector2 worldCoords, float size)
    {
        WaterPoolFactory.InstantiateChunk(gameObject, worldCoords, size);
    }
    public void MakePoisonPool(Vector2 worldCoords, float size)
    {
        PoisonPoolFactory.InstantiateChunk(gameObject, worldCoords, size);
    }
    public void MakeFloor(Vector2 worldCoords, float size)
    {
        FloorFactory.InstantiateChunk(gameObject, worldCoords, size);
    }


    void OnMouseDown()
    {
        Vector2 worldCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldCoords = new Vector2(Mathf.Floor(worldCoords.x), Mathf.Floor(worldCoords.y));
        float size = Mathf.Floor(Input.mousePosition.y / Screen.height * 10 + 1);

        int chunkType = Random.Range(0, 4);
        switch (chunkType) {
            case 0:
                MakeLavaPool(worldCoords, size);
                break;
            case 1:
                MakeWaterPool(worldCoords, size);
                break;
            case 2:
                MakePoisonPool(worldCoords, size);
                break;
            default:
                MakeFloor(worldCoords, size);
                break;
        }
    }
}
