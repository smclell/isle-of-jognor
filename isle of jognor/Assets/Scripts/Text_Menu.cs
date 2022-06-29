using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_Menu : MonoBehaviour
{
    private Transform textArea;
    private Transform textMenu;
    private Transform menus;
    public float timeRemaining;
    private bool open;

    // Start is called before the first frame update
    void Awake()
    {
        textMenu = transform.Find("text_Background");
        textArea = transform.Find("textHolder");
        open = true;
        timeRemaining = 5;

        //updateTalkText("Move with WASD, Interact with E \n Open/Close Quest menu with Tab.");
    }

    public void updateTalkText(string text)
    {
        TextMeshProUGUI talkingText = textMenu.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        talkingText.SetText(text);
    }
    public void Update()
    {
        if (open)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                open = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
