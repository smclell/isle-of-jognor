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
    public bool enabled;

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
        foreach (Transform child in questSlotContainer)
        {
            if (child == questSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        float x = -0.5f;
        float y = 0.25f;
        float questSlotCellSize = 35f;
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
                        if (clue.clueType.ToString() == "End")
                        {
                            shownClues = clue.clueInfo;
                            quest.finished = true;
                        }
                        else
                        {
                            shownClues += "- " + clue.clueInfo + " \n";
                        }
                    }
                    else
                    {
                        if (clue.clueType.ToString() != "End")
                            shownClues += "- Hidden Clue \n";
                    }
                }
                questClues.SetText(shownClues);

                y--;
            }            
        }
    }
}
