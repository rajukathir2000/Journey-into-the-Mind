//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class StageTransition : MonoBehaviour
//{
//    public void Button1()
//    {
//        SceneManager.LoadSceneAsync(2);
//    }

//    public void Button2()
//    {
//        SceneManager.LoadScene(3);
//    }

//    public void Button3()
//    {
//        SceneManager.LoadScene(4);
//    }

//    public void Stage0to1()
//    {
//        SceneManager.LoadSceneAsync(1);
//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour
{
    public void Button1()
    {
        StartCoroutine(LoadSceneAfterDelay(2));
    }

    public void Button2()
    {
        StartCoroutine(LoadSceneAfterDelay(3));
    }

    public void Button3()
    {
        StartCoroutine(LoadSceneAfterDelay(4));
    }

    public void Stage0to1()
    {
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        SceneManager.LoadSceneAsync(sceneIndex); // Load the scene asynchronously
    }
}
