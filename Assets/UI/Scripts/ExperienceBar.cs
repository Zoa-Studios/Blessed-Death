using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public float CurrentExp { get; set; }
    public float MaxExp { get; set; }

    private Slider experienceBar;

    public float FillSpeed = 0.2f;
    private float targetProgress = 0;

    private void Awake()
    {
        experienceBar = gameObject.GetComponent<Slider>();

    }

    // Start is called before the first frame update
    void Start()
    {
        MaxExp = 0f;
        // Resets Experience to full on game load
        CurrentExp = MaxExp;

        experienceBar.value = CalculateExp();

    }

    // Update is called once per frame
    void Update()
    {
        if (experienceBar.value < targetProgress)
            experienceBar.value += FillSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
            IncrementProgress(0.10f);
    }

    void DealExp(float ExpValue)
    {
        // Deduct the Experience gain from the character's enemy kill
        CurrentExp -= ExpValue;
        experienceBar.value = CalculateExp();
        // If the character is full of experience, level up!
        if (CurrentExp >= 1)
            LevelUp();
    }

    // Add progress to the bar
    public void IncrementProgress(float newProgress)
    {
        targetProgress = experienceBar.value + newProgress;
    }

    float CalculateExp()
    {
        return CurrentExp / MaxExp;
    }

    void LevelUp()
    {
        CurrentExp = 1;
        Debug.Log("Livellato bro");
    }
}
