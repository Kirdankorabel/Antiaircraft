using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo
{
    public static readonly string path = Application.streamingAssetsPath + "/";
    public static readonly string manifestName = "StreamingAssets";
    public static readonly List<string> paths = new List<string>
    {
        "sounds",
        "musics",
    };
}