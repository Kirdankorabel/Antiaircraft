using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Store
{
    private static Dictionary<string, Object[]> _store = new Dictionary<string, Object[]>();

    public static List<T> GetAllAssets<T>(string assetBundleName) where T : Object
    {
        if (!_store.ContainsKey(assetBundleName))
            throw new System.Exception("AssetsBundle not found: " + assetBundleName);

        var result = new List<T>();
        foreach (var item in _store[assetBundleName])
            if (item is T)
                result.Add((T)item);
            else throw new System.Exception("Incorrect type");
        return result;
    }

    public static void LoadBandle(AssetBundle assetBundle)
        => _store.Add(assetBundle.name, assetBundle.LoadAllAssets());

    public static T GetAsset<T>(string assetBundleName, string name) where T : Object
    {
        if (!_store.ContainsKey(assetBundleName))
            throw new System.Exception("AssetsBundle not found: " + assetBundleName);
        var result = _store[assetBundleName].FirstOrDefault(item => item.name == name);
        return result as T;
    }
}