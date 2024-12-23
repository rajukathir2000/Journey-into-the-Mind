using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S1Player : MonoBehaviour
{
    public Animator nurseAnim;
    public AudioSource audioSource;
    public AudioClip closeEyes, thanking;
    public Image blackPanel;
    public ParticleSystem startParticle, carParticle;
    public GameObject Nurse;

    private void Awake()
    {
        StartCoroutine(FadeOut());
    }
    private void Start()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;

        string lastScene = PlayerPrefs.GetString("LastScene","");
        Debug.Log(lastScene);
        if (lastScene == "Mind")
        {
            Invoke(nameof(PlayAudioFromMind),2f);
        }
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("LastScene", "SafeRoom");
        PlayerPrefs.Save();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("StartMarker"))
        {
            startParticle.gameObject.SetActive(false);
            Debug.Log("StartedTherapy");
            nurseAnim.SetBool("Start", true);
            Invoke(nameof(NurseIntro), 3f);
            Invoke(nameof(GetInCar), 14f);
        }
        else if(other.gameObject.CompareTag("CarMarker"))
        {
            carParticle.gameObject.SetActive(false);
            Debug.Log("GetIncar");
            gameObject.transform.SetPositionAndRotation(new Vector3(0.6f, -0.5f, -12.5f),Quaternion.Euler(0f, 0f, 0f));
            Debug.Log(transform.position);
            Invoke(nameof(CloseEyes), 3f);
        }
    }

    private void NurseIntro()
    {
        audioSource.Play();
    }

    private void GetInCar()
    {
        carParticle.gameObject.SetActive(true);        
        nurseAnim.SetBool("Start", false);
        nurseAnim.SetBool("GetIn", true);
    }

    void CloseEyes()
    {
        audioSource.clip = closeEyes;
        audioSource.Play();
        StartCoroutine(FadeIn());
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private IEnumerator FadeIn()
    {
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
    }

    void PlayAudioFromMind()
    {
        audioSource.clip = thanking;
        audioSource.Play();
        //Nurse.SetActive(true);
        Nurse.transform.position = new Vector3(0,0.4f,-4.5f);
        nurseAnim.SetBool("Thanks", true);

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
