using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        var scenesNumber = SceneManager.sceneCount;
        for (int i = 0; i < scenesNumber; i++)
        {
            Debug.Log(SceneManager.GetSceneAt(i).name);
            //Chiude tutte le scene aperte ed apre la scena all'indice 1 della lista di build delle scene.
            //La lista può essere trovata in File>Build Settings
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }


}
