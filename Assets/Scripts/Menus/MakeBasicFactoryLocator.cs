using UnityEditor;
using UnityEngine;

public class MakeBasicFactoryLocator {
    [MenuItem("Assets/Create/Chunk Factories/Basic Chunk Factory Locator")]
    public static void CreateBasicChunkFactoryLocator()
    {
        BasicFactoryServiceLocator asset = ScriptableObject.CreateInstance<BasicFactoryServiceLocator>();

        AssetDatabase.CreateAsset(asset, "Assets/Scripts/FactoryScriptableObjects/BasicFactoryServiceLocator.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
