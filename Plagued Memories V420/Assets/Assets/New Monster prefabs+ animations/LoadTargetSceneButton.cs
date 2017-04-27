using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTargetSceneButton : MonoBehaviour
{

    public void LoadSceneNum(int num)
    {
        if(num<0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            return;
        }
        LoadingScreenManager.LoadScene(num);
    }
}
