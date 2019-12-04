using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToPrimaryMenu : MonoBehaviour
{
    public Button BackButton;
    // inizializzo un array di button, che scompariranno per far spazio ai bottoni delle opzioni
    public List<GameObject> PrimaryMenuButtonList = new List<GameObject>();
    // bottoni del sottomenù opzioni
    public List<GameObject> OptionsMenuButtonList = new List<GameObject>();
    void Start()
    {
        BackButton.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (PrimaryMenuButtonList.Count > 0 && OptionsMenuButtonList.Count > 0)
        {
            foreach (GameObject button in PrimaryMenuButtonList)
            {
                button.SetActive(true);
            }
            foreach (GameObject button in OptionsMenuButtonList)
            {
                button.SetActive(false);

            }

        }
        else
        {
            Debug.LogWarning("Dovresti inserire dei bottoni per il menù primario e per il menù delle opzioni");
        }
    }
}
