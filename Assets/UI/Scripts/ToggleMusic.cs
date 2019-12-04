using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleMusic : MonoBehaviour
{
    public Button VolumeButton;
    public Text Text;

    private void Start()
    {
        ControlMusicPrefs();
    }

    void EnableAudio()
    {
        Text.text = "AUDIO ON";
        AudioListener.volume = 1f;
    }

    void DisableAudio()
    {
        Text.text = "AUDIO OFF";
        AudioListener.volume = 0f;
    }

    void ControlMusicPrefs()
    {
        VolumeButton.onClick.AddListener(TaskOnClick);
        

        //Make sure the entry on the Prefs exist or proceed to create it
        if (PlayerPrefs.HasKey("Audio"))
        {
            if (PlayerPrefs.GetInt("Audio") == 1)
            {
                EnableAudio();
            } else
            {
                DisableAudio();
            }
        }
        else
        {
            AudioListener.volume = 1.0f;
            PlayerPrefs.SetInt("Audio", 1);
            Text.text = "AUDIO ON";
            PlayerPrefs.Save();
        }
    }

    void TaskOnClick()
    {
        if (PlayerPrefs.GetInt("Audio", 1) != 1)
        {
            PlayerPrefs.SetInt("Audio", 1);
            EnableAudio();
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 0);
            DisableAudio();
        }
    }
}
