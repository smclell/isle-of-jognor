using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private QuestList questList;
    private Transform questSlotContainer;
    private Transform questSlotTemplate;

    private void Awake()
    {
        questSlotContainer = transform.Find("questSlotContainer");
        questSlotTemplate = questSlotContainer.Find("questSlotTemplate");
    }

    public void setQuestList(QuestList questList)
    {
        this.questList = questList;
        RefreshQuestList();
    }

    public void RefreshQuestList()
    {
        int x = 0;
        int y = 0;
        float questSlotCellSize = 30f;
        foreach (Quest quest in questList.getQuestList())
        {
            if (quest.started)
            {
                RectTransform questSlotRectTransform = Instantiate(questSlotTemplate, questSlotContainer).GetComponent<RectTransform>();
                questSlotRectTransform.gameObject.SetActive(true);

                questSlotRectTransform.anchoredPosition = new Vector2(x * questSlotCellSize, y * questSlotCellSize);

                TextMeshProUGUI questTitle = questSlotRectTransform.Find("questTitle").GetComponent<TextMeshProUGUI>();
                questTitle.SetText(quest.questTitle);
                TextMeshProUGUI questInfo = questSlotRectTransform.Find("questInfo").GetComponent<TextMeshProUGUI>();
                questInfo.SetText(quest.questInfo);

                TextMeshProUGUI questClues = questSlotRectTransform.Find("questClues").GetComponent<TextMeshProUGUI>();
                string shownClues = "";
                foreach (Clue clue in quest.clueList)
                {
                    if (clue.found)
                    {
                        shownClues += "- " + clue.clueInfo + " \n";
                    }
                    else
                    {
                        shownClues += "- Hidden Clue \n";
                    }
                }
                questClues.SetText(shownClues);

                y--;
            }            
        }
    }
}
