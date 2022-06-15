using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestList
{
    public List<Quest> questList;

    public QuestList() {
        questList = new List<Quest>();
        List<string> tempLocationList = new List<string> { "Jamie's House", "the old windmill" };
        List<string> tempNameList = new List<string> { "Dave", "Jamie", "Jamie's Mom" };

        addQuest(new Quest { questInfo = "Find out what happened to Jamie" });

        foreach (string loc in tempLocationList)
        {
            questList.Last().addLocation(loc);
        }
        foreach (string name in tempNameList)
        {
            questList.Last().addInvolved(name);
        }

        questList.Last().addClueInfo();

        
    }

    public void addQuest(Quest quest)
    {
        questList.Add(quest);
    } 
}
