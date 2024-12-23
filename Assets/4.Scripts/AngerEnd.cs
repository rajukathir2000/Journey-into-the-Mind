using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngerEnd : MonoBehaviour
{
    public Button toggleButton;
    public GameObject Nose, Hand,Nurse,key,audioMove;
    public TMP_Text lastText;
    public int delay;

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(StartAnim);
            Debug.Log("Toggle button listener added.");
        }
        else
        {
            Debug.LogError("Toggle button is not assigned.");
        }

    }

    void StartAnim()
    {
        toggleButton.gameObject.SetActive(false);
        Hand.SetActive(true);
        Nose.SetActive(true);
        Invoke(nameof(ClosingSession), delay);
        audioMove.GetComponent<Move>().enabled = true;
    }

    void ClosingSession()
    {
        Invoke(nameof(Key), 3f);
        lastText.text = "Your anger has subsided after this therapy. Here's your key to the safe room.";
        Hand.SetActive(false);
        Nose.SetActive(false);
        Nurse.SetActive(true);
    }

    void Key()
    {
        Instantiate(key, new Vector3(0, 1.5f, 2.25f), Quaternion.identity);
    }

}
