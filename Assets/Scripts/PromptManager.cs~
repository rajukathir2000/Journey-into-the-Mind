using TMPro;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public string[] prompts;
    public AudioClip[] PromptsClips;
    public AudioSource PromptSource;
    public TMP_Text promptsTXT;
    
    public void TriggerPrompt(int promptIndex)
    {
        Debug.Log("triggered prompt");
        if (promptIndex >= 0 && promptIndex < prompts.Length && promptIndex < PromptsClips.Length)
        {
            PromptSource.clip = PromptsClips[promptIndex];
            PromptSource.Play();
            promptsTXT.text = prompts[promptIndex];
            Debug.Log($"Prompt triggered: {prompts[promptIndex]}");
        }
        else
        {
            Debug.LogWarning($"Invalid prompt index: {promptIndex}");
        }
    }
}

