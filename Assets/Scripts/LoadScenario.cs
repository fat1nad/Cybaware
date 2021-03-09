using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScenario : MonoBehaviour
{

    [SerializeField]
    string sceneName;
    public void LoadScenario1()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScenario2()
    {
        string assetLocation = Path.Combine(Application.streamingAssetsPath, sceneName);
        AssetBundle scenario2 = AssetBundle.LoadFromFile(assetLocation);
        
        if (scenario2 == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        if (scenario2.isStreamedSceneAssetBundle)
        {
            string[] scenePaths = scenario2.GetAllScenePaths();
            string sceneName = Path.GetFileNameWithoutExtension(scenePaths[0]);
            SceneManager.LoadScene(sceneName);
        }
    }
}
