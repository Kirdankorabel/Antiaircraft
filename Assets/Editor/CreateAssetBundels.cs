using UnityEditor;

public class CreateAssetBundels
{
    [MenuItem("Assets/Buld BuildAllAssetBundelsFowWindows")]
    public static void BuildAllAssetBundelsFowWindows()
    {
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
    [MenuItem("Assets/Buld BuildAllAssetBundelsFowAndroid")]
    public static void BuildAllAssetBundelsFowAndroid()
    {
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
