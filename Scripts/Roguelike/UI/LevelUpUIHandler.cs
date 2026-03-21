using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using TMPro;

public class LevelUpUIHandler : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public UnityEvent LevelUpEvent;
    public LevelUpHandler LUH;
    public List<LevelUpOptionsBase> options;
    // Start is called before the first frame update
    void Start()
    {
        HideCanvas();
        PlayerStats playerStats = GameObject.FindFirstObjectByType<PlayerStats>();
        LUH = gameObject.GetComponent<LevelUpHandler>();
        LevelUpEvent = playerStats.LevelUpEvent;
        LevelUpEvent.AddListener(ShowCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideCanvas();
        }
    }

    public void SelectOption1()
    {
        options[0]?.Execute();
        HideCanvas();
    }
    
    public void SelectOption2()
    {
        options[1]?.Execute();
        HideCanvas();
    }

    public void SelectOption3()
    {
        options[2]?.Execute();
        HideCanvas();
    }
    
    public void SelectOption4()
    {
        options[3]?.Execute();
        HideCanvas();
    }

    public void HideCanvas()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        Time.timeScale = 1f;
    }

    public void ShowCanvas()
    {
        options = LUH.GetOptions();
        UpdateOptionDescription();

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0f;
    }

    private void UpdateOptionDescription()
    {
        List<TextMeshProUGUI> buttonTexts = gameObject.GetComponentsInChildren<TextMeshProUGUI>().ToList();
        foreach (var buttonText in buttonTexts)
        {
            buttonText.text = options[buttonTexts.IndexOf(buttonText)].GetDescription();
        }
    }
}
