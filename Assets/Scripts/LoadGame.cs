using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    public void changemenuscene(string scenename)
    {
       SceneManager.LoadScene(scenename,LoadSceneMode.Single);
    }
}
