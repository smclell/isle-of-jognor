using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestList
{
    public List<Quest> questList;
    public List<Clue.ClueType> tempObjectList;
    public List<string> tempLocationList;
    public List<string> tempNameList;

    public QuestList() {
        questList = new List<Quest>();
        tempLocationList = new List<string> { "Jamie's House", "the old windmill" };
        tempNameList = new List<string> { "Dave", "Jamie", "Jamie's Mom" };
        tempObjectList = new List<Clue.ClueType> { Clue.ClueType.Blood, Clue.ClueType.Object, Clue.ClueType.Key };

        addQuest(new Quest("Missing Son and Friend", "Dave heard from Jamie's Mother that she hasn't seen him in a long time and asks if you can go to his house to see if he is there.", 3));
        populateLists();

        tempLocationList = new List<string> { "Blacksmith", "Greg's farm" };
        tempNameList = new List<string> { "Jeff the Blacksmith", "Greg", "Greg" };
        tempObjectList = new List<Clue.ClueType> { Clue.ClueType.Object, Clue.ClueType.Blood, Clue.ClueType.Key };

        addQuest(new Quest ("The farmer's new tool", "Jeff completed an order for Greg for a new tool but has been too busy to take it to him, take the tool to Greg for him.", 3));
        populateLists();

        foreach (Quest quest in questList)
        {
            quest.addClueInfo();
        }
    }

    public void populateLists()
    {
        foreach (string loc in tempLocationList)
        {
            questList.Last().addLocation(loc);
        }
        foreach (string name in tempNameList)
        {
            questList.Last().addInvolved(name);
        }
    }

    public void addQuest(Quest quest)
    {
        questList.Add(quest);

        int x = 0;
        foreach (Clue clue in quest.clueList)
        {
            clue.clueType = tempObjectList[x];
            x++;
        }
    }

    public List<Quest> getQuestList()
    {
        return questList;
    }
}
