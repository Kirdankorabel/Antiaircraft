using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundlesLoader : MonoBehaviour
{
    private List<WWW> _store = new List<WWW>();
    private int counter = 0;

    public static event Action BundelsLoaded;

    private void Awake()
    {
        try
        {
            StartCoroutine(DownloadAll());
        }
        catch
        {
            Application.Quit();
        }
    }

    private void OnApplicationQuit()
    {
        foreach (var www in _store)
            www.assetBundle.Unload(true);
    }

    private IEnumerator DownloadAll()
    {
        foreach (var item in StaticInfo.paths)
        {
            counter++;
            yield return StartCoroutine(Download(item));
        }
        StartCoroutine(WaiteCorutine());
        yield return null;
    }

    private IEnumerator Download(string bundelName)
    {
        AssetBundleManifest manifest;
        using (var www = new WWW(StaticInfo.path + StaticInfo.manifestName))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }
            manifest = www.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            yield return null;
            www.assetBundle.Unload(false);
            _store.Add(www);
        }

        using (var www = WWW.LoadFromCacheOrDownload(StaticInfo.path + bundelName, manifest.GetAssetBundleHash(bundelName)))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }
            Store.LoadBandle(www.assetBundle);
            counter--;
            yield return null;
            www.assetBundle.Unload(false);
            _store.Add(www);
        }
    }

    private IEnumerator WaiteCorutine()
    {
        while(counter > 0)
            yield return null;
        BundelsLoaded?.Invoke();
        yield return null;
    }
} 