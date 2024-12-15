using UnityEngine;
using UnityEngine.UI;

public class BreathingOrb : MonoBehaviour
{
    public Button toggleButton; // Reference to the Button
    public Text buttonText;     // Reference to the Button's Text
    private bool isBreathing;  // State of the animation
    public string line;
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Ensure the button and text are assigned
        if (toggleButton != null)
        {
            // Attach the method to the button's click event
            toggleButton.onClick.AddListener(ToggleBreathing);
        }
    }

    public void ToggleBreathing()
    {
        isBreathing = !isBreathing; // Toggle the breathing state

        if (isBreathing)
        {
            buttonText.text = line;// Update the button text
            StartBreathingAnimation(); // Start the breathing animation
        }
        else
        {
            StopBreathingAnimation(); // Stop the breathing animation
        }
    }

    public void StartBreathingAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("StartBreathing",true);
            //toggleButton.interactable = false;
        }
    }

    public void StopBreathingAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("StartBreathing", false); // Stop the animation trigger
        }
    }
}
