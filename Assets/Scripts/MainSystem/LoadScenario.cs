using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;
public class LoadScenario : MonoBehaviour
{
    [SerializeField]
    Image fadeBG;

    bool faded = false;

    TextMeshProUGUI sceneName;

    private void Start()
    {
        sceneName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Debug.Log(sceneName.text);
    }

    private void Update()
    {
        if (faded == true && fadeBG.color.a < 1f)
        {
            fadeBG.transform.SetAsLastSibling();
            fadeBG.color = new Color(fadeBG.color.r, fadeBG.color.g, fadeBG.color.b, fadeBG.color.a + 0.025f);


            if (fadeBG.color.a >= 1f)
            {
                Debug.Log("BG Faded.");
                LoadScene();
            }
        }
    }

    public void LoadScene()
    {
        if (faded == false)
        {
            faded = true;
        }
        else if (faded == true)
        {
            faded = false;

            Scene loadedScene = SceneManager.LoadScene(sceneName.text, new LoadSceneParameters(LoadSceneMode.Single));

            if (loadedScene.isLoaded)
            {
                fadeBG.transform.SetAsFirstSibling();
                fadeBG.color = new Color(fadeBG.color.r, fadeBG.color.g, fadeBG.color.b, 0f);
            }

        }
    }
}