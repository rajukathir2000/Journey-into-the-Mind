using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour
{
    public void Button1()
    {
        SceneManager.LoadScene(2);
    }

    public void Button2()
    {
        SceneManager.LoadScene(3);
    }

    public void Button3()
    {
        SceneManager.LoadScene(4);
    }

    public void Stage0to1()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
