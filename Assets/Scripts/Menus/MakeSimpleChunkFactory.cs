using UnityEditor;
using UnityEngine;

public class MakeSimpleChunkFactory {
    [MenuItem("Assets/Create/Chunk Factories/Simple Chunk Factory")]
    public static void CreateMyAsset()
    {
        SimpleChunkFactory asset = ScriptableObject.CreateInstance<SimpleChunkFactory>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/FactoryScriptableObjects/SimpleChunkFactory.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
