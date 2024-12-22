using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S3_3Player : MonoBehaviour
{
    public Image blackPanel;
    public AudioSource portalVFX;

    private void Awake()
    {
        StartCoroutine(FadeOut());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        portalVFX.Play();
        float duration = 2f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);
            blackPanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackPanel.color = new Color(0, 0, 0, 1);
        SceneManager.LoadSceneAsync(1);
    }

    private IEnumerator FadeOut()
    {
        float duration = 2f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, currentTime / duration);
            blackPanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackPanel.color = new Color(0, 0, 0, 0);
    }
}
