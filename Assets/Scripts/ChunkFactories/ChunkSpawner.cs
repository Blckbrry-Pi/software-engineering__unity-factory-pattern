using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public int ChunkCount = 0;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "SpawnBoundary")
        {
            int factoryCount = FactoryServiceLocator.Instance.Factories.Count;
            int factoryIndex = Random.Range(0, factoryCount);
            MapChunkFactory chunkFactory = FactoryServiceLocator.Instance.Factories[factoryIndex];
            int size = 8 * Random.Range(3, 5);
            chunkFactory.InstantiateChunk(gameObject, transform.position - new Vector3(15, 0, 0), size);

            transform.position += new Vector3(size + Random.Range(0, 2), 0, 0);

            ChunkCount++;
        }
    }
}
