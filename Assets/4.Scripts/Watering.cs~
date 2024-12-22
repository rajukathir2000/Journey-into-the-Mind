using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Watering : MonoBehaviour
{
    public Button button;
    public Animator treeAnim,leverAnim;
    public ParticleSystem rainParticle;
    public GameObject lever;
    public AudioSource rain;
    void Start()
    {
        leverAnim = lever.GetComponent<Animator>();
        treeAnim.gameObject.SetActive(false);
        rainParticle.gameObject.SetActive(false);
        button.onClick.AddListener(OnWateringButtonClick);
    }

    void OnWateringButtonClick()
    {
        leverAnim.SetBool("Toggle", true);
        treeAnim.gameObject.SetActive(true);
        rainParticle.gameObject.SetActive(true);
        rain.Play();
        StartCoroutine(StopRainParticlesAfterDelay(10f));
    }

    IEnumerator StopRainParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rainParticle.Stop();
        rainParticle.gameObject.SetActive(false);
    }
}
