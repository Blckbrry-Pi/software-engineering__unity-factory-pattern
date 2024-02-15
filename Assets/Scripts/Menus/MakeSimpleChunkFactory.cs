using UnityEditor;
using UnityEngine;

public class MakeSimpleChunkFactory {
    [MenuItem("Assets/Create/Chunk Factories/Simple Chunk Factory")]
    public static void CreateSimpleChunkFactory()
    {
        SimpleChunkFactory asset = ScriptableObject.CreateInstance<SimpleChunkFactory>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/FactoryScriptableObjects/Basic Factories/SimpleChunkFactory.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
