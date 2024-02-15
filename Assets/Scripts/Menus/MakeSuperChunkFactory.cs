using UnityEditor;
using UnityEngine;

public class MakeSuperChunkFactory {
    public static void CreateAsset(ScriptableObject asset, string path) {
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/FactoryScriptableObjects/Super Factories/" + path);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Chunk Factories/Split Pool Chunk Factory")]
    public static void CreateSplitPoolChunk()
    {
        CreateAsset(ScriptableObject.CreateInstance<SplitPoolChunk>(), "SplitPoolChunk.asset");
    }

    [MenuItem("Assets/Create/Chunk Factories/Poison Pool Chunk Factory")]
    public static void CreatePoisonPoolChunk()
    {
        CreateAsset(ScriptableObject.CreateInstance<PoisonPoolChunk>(), "PoisonPoolChunk.asset");
    }

    [MenuItem("Assets/Create/Chunk Factories/Little Pool Chunk Factory")]
    public static void CreateLittlePoolChunk()
    {
        CreateAsset(ScriptableObject.CreateInstance<LittlePoolChunk>(), "LittlePoolChunk.asset");
    }
}
