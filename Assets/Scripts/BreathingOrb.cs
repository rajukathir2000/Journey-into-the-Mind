using UnityEngine;
using UnityEngine.UI;

public class BreathingOrb : MonoBehaviour
{
    public Button toggleButton; // Reference to the Button
    public Text buttonText;     // Reference to the Button's Text
    private bool isBreathing;  // State of the animation
    public string line;
    public Animator animator;
    public GameObject Lungs,Nurse;

    void Start()
    {
        if (Lungs != null)
        {
            animator = Lungs.GetComponent<Animator>();
        }
        else if (animator = null) 
        {
            Debug.Log("Nulled");
        }
        

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleBreathing);
        }
    }


    public void ToggleBreathing()
    {
        isBreathing = !isBreathing; // Toggle the breathing state

        if (isBreathing)
        {
            buttonText.text = line;// Update the button text
            StartAnimating(); // Start the breathing animation
        }
       
    }

    public void StartAnimating()
    {
        if (animator != null)
        {
            animator.SetBool("Started",true);
            animator.SetBool("Completed", false);
            //toggleButton.interactable = false;
        }
    }

    public void LungsToNurse()
    {
        Debug.Log($"Switching from Lungs to Nurse. Lungs active: {Lungs.activeSelf}, Nurse active: {Nurse.activeSelf}");

        if (Lungs != null) Lungs.SetActive(false);
        if (Nurse != null)
        {
            Nurse.SetActive(true);
            animator = null;
            //animator = Nurse.GetComponent<Animator>();
           // Debug.Log($"Animator assigned to Nurse: {animator != null}");
        }
        else
        {
            Debug.LogError("Nurse GameObject is not assigned!");
        }
    }


    public void BreathinPrompt()
    {

    }
}
