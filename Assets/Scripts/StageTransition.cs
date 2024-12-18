<<<<<<< Updated upstream
////using System.Collections;
////using UnityEngine;
////using UnityEngine.SceneManagement;

////public class StageTransition : MonoBehaviour
////{
////    public GameObject[] chest; // Array of chests or buttons
////    public AudioSource inMindAudio;
////    private void Start()
////    {
////        // Check and set button states when the scene loads
////        for (int i = 0; i < chest.Length; i++)
////        {
////            if (PlayerPrefs.GetInt("Chest" + i, 1) == 0) // Default is active (1)
////            {
////                gameObject.GetComponent<AudioSource>().enabled = false;
////                chest[i].SetActive(false);
////            }
////        }
////    }

////    public void Button1()
////    {
////        SetChestInactive(0);
////        StartCoroutine(LoadSceneAfterDelay(2));
////    }

////    public void Button2()
////    {
////        SetChestInactive(1);
////        StartCoroutine(LoadSceneAfterDelay(3));
////    }

////    public void Button3()
////    {
////        SetChestInactive(2);
////        StartCoroutine(LoadSceneAfterDelay(4));
////    }

////    public void Stage0to1()
////    {
////        StartCoroutine(LoadSceneAfterDelay(1));
////    }

////    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
////    {
////        yield return new WaitForSeconds(3f); // Wait for 3 seconds
////        SceneManager.LoadSceneAsync(sceneIndex); // Load the scene asynchronously
////    }

////    private void SetChestInactive(int chestIndex)
////    {
////        // Save the state of the button using PlayerPrefs
////        PlayerPrefs.SetInt("Chest" + chestIndex, 0); // 0 = Inactive
////        PlayerPrefs.Save();
////    }
////}

//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class StageTransition : MonoBehaviour
//{
//    public GameObject[] chest; // Array of chests or buttons
//    public AudioClip returnclip, closingClip;

//    private void Start()
//    {
//        // Check if starting from Scene 0 and reset PlayerPrefs
//        if (SceneManager.GetActiveScene().buildIndex == 0)
//        {
//            PlayerPrefs.DeleteAll(); // Reset all saved states
//            PlayerPrefs.Save();
//        }

//        // Check and set button states when the scene loads
//        for (int i = 0; i < chest.Length; i++)
//        {
//            if (PlayerPrefs.GetInt("Chest" + i, 1) == 0) // Default is active (1)
//            {
//                gameObject.GetComponent<AudioSource>().clip = returnclip;
//                chest[i].SetActive(false);
//            }
//        }
//    }

//    public void Button1()
//    {
//        SetChestInactive(0);
//        StartCoroutine(LoadSceneAfterDelay(2));
//    }

//    public void Button2()
//    {
//        SetChestInactive(1);
//        StartCoroutine(LoadSceneAfterDelay(3));
//    }

//    public void Button3()
//    {
//        SetChestInactive(2);
//        StartCoroutine(LoadSceneAfterDelay(4));
//    }

//    public void Stage0to1()
//    {
//        StartCoroutine(LoadSceneAfterDelay(1));
//    }

//    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
//    {
//        yield return new WaitForSeconds(3f); // Wait for 3 seconds
//        SceneManager.LoadSceneAsync(sceneIndex); // Load the scene asynchronously
//    }

//    private void SetChestInactive(int chestIndex)
//    {
//        // Save the state of the button using PlayerPrefs
//        PlayerPrefs.SetInt("Chest" + chestIndex, 0); // 0 = Inactive
//        PlayerPrefs.Save();
//    }
//}

=======
>>>>>>> Stashed changes
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject[] chest; // Array of chests/buttons
    public AudioSource audioSource; // Audio Source component for playing audio
    public AudioClip returnClip1, returnClip2, returnClip3, safeRoomClip; // Audio clips
=======
    public GameObject[] chest;
    public AudioSource audioSource;
    public AudioClip allClearedClip, chestAvailableClip, fromSafeRoomClip;
>>>>>>> Stashed changes

    private void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
<<<<<<< Updated upstream

        // Check if starting from Safe Room (Scene 0) and reset everything
        if (currentScene == 0)
        {
            PlayerPrefs.DeleteAll(); // Reset saved states
            PlayerPrefs.Save();
            PlaySafeRoomClip();
            return; // Exit further logic for Scene 0
        }

        // Scene 1: Setup chest visibility and play appropriate return audio
        if (currentScene == 1)
        {
            bool allChestsCleared = true; // Flag to check if all chests are inactive

            for (int i = 0; i < chest.Length; i++)
            {
                if (PlayerPrefs.GetInt("Chest" + i, 1) == 0) // If chest is inactive
                {
                    chest[i].SetActive(false); // Hide the chest
                }
                else
                {
                    chest[i].SetActive(true); // Show the chest
                    allChestsCleared = false; // At least one chest is still visible
                }
            }

            // Play audio based on the state of the chests
            if (allChestsCleared)
            {
                PlaySafeRoomClip(); // Play Safe Room clip if all chests are cleared
            }
            else
            {
                PlayReturnAudio(); // Play audio for returning from specific scenes
=======
        if (currentScene == 0)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("LastScene", "SafeRoom");
            PlayerPrefs.Save();
            PlayFromSafeRoomClip();
            return;
        }
        if (currentScene == 1)
        {
            bool allChestsCleared = true;

            for (int i = 0; i < chest.Length; i++)
            {
                if (PlayerPrefs.GetInt("Chest" + i, 1) == 0)
                {
                    chest[i].SetActive(false);
                }
                else
                {
                    chest[i].SetActive(true);
                    allChestsCleared = false;
                }
            }

            string lastScene = PlayerPrefs.GetString("LastScene", "");
            if (lastScene == "SafeRoom")
            {
                PlayFromSafeRoomClip();
            }
            else if (lastScene == "Button1" || lastScene == "Button2")
            {
                if (allChestsCleared)
                {
                    PlayAllClearedAudio();
                }
                else
                {
                    PlayChestAvailableAudio();
                }
            }
            else
            {
                audioSource.Stop();
>>>>>>> Stashed changes
            }
        }
    }

    public void Button1()
    {
        SetChestInactive(0);
<<<<<<< Updated upstream
        StartCoroutine(LoadSceneAfterDelay(2, "Button1")); // Angry Scene
=======
        StartCoroutine(LoadSceneAfterDelay(2, "Button1"));
>>>>>>> Stashed changes
    }

    public void Button2()
    {
        SetChestInactive(1);
<<<<<<< Updated upstream
        StartCoroutine(LoadSceneAfterDelay(3, "Button2")); // Fear Scene
=======
        StartCoroutine(LoadSceneAfterDelay(4, "Button2"));
>>>>>>> Stashed changes
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, string buttonName)
    {
<<<<<<< Updated upstream
        SetChestInactive(2);
        StartCoroutine(LoadSceneAfterDelay(4, "Button3")); // Anxiety Scene
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, string buttonName)
    {
        PlayerPrefs.SetString("LastScene", buttonName); // Save the last button clicked
        PlayerPrefs.Save();
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadSceneAsync(sceneIndex); // Load the mapped scene
    }

    private void SetChestInactive(int chestIndex)
    {
        PlayerPrefs.SetInt("Chest" + chestIndex, 0); // Save chest state as inactive
        PlayerPrefs.Save();
    }

    private void PlayReturnAudio()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "");

        switch (lastScene)
        {
            case "Button1":
                audioSource.clip = returnClip1; // Return from Angry Scene
                break;
            case "Button2":
                audioSource.clip = returnClip2; // Return from Fear Scene
                break;
            case "Button3":
                audioSource.clip = returnClip3; // Return from Anxiety Scene
                break;
            default:
                audioSource.clip = null;
                break;
        }

        if (audioSource.clip != null)
        {
            audioSource.Play(); // Play the return audio clip
        }
    }

    private void PlaySafeRoomClip()
    {
        audioSource.clip = safeRoomClip; // Play Safe Room audio
=======
        PlayerPrefs.SetString("LastScene", buttonName);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private void SetChestInactive(int chestIndex)
    {
        PlayerPrefs.SetInt("Chest" + chestIndex, 0);
    }

    private void PlayChestAvailableAudio()
    {
        audioSource.clip = chestAvailableClip;
        audioSource.Play();
    }

    private void PlayAllClearedAudio()
    {
        audioSource.clip = allClearedClip;
        audioSource.Play();
    }

    private void PlayFromSafeRoomClip()
    {
        audioSource.clip = fromSafeRoomClip;
>>>>>>> Stashed changes
        audioSource.Play();
    }
}
