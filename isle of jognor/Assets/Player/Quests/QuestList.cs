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
        tempNameList = new List<string> { "Dave", "Jamie", "Jamie's Mom", "- You have found out what happened to Jamie, and glad that the animal that took him down went down with him." };
        tempObjectList = new List<Clue.ClueType> { Clue.ClueType.Blood, Clue.ClueType.Object, Clue.ClueType.Key, Clue.ClueType.End };
        bool needKey = true;

        addQuest(new Quest("Missing Son and Friend", "Dave heard from Jamie's Mother that she hasn't seen Jamie in a while and asks if you can go to his house to see if he is there.", 4, needKey));
        populateLists();


        tempLocationList = new List<string> { "Blacksmith", "Greg's farm" };
        tempNameList = new List<string> { "Jeff the Blacksmith", "Greg", "- Grag thanks you for bringing him his new tool, telling you that a village just over the hill has recently had a lot of cases for extreme sickness or even madness and asked that if you have the town you might want to check it out." };
        tempObjectList = new List<Clue.ClueType> { Clue.ClueType.Object, Clue.ClueType.Key, Clue.ClueType.End };
        needKey = true;

        addQuest(new Quest ("The farmer's new tool", "Jeff completed an order for Greg for a new tool but has been too busy to take it to him, take the tool to Greg for him.", 3, needKey));
        populateLists();


        tempLocationList = new List<string> { "Apothecary", "Sick Hut" };
        tempNameList = new List<string> { "Henry the Apothecary", "one of the 'infected' ones", "- Henry will be troubled to find out that all of the 'infected ones' have passed away seemingly from what looks like a massive brawl. Hopefully he might be able to tell you more about what he knows of this so called 'disease'." };
        tempObjectList = new List<Clue.ClueType> { Clue.ClueType.Blood, Clue.ClueType.Blood, Clue.ClueType.End };
        needKey = false;

        addQuest(new Quest("Maddeningly Sick", "Henry wants you to check up on some 'infected ones' while he attempts to create a cure for them, check the so called Sick Hut out.", 3, needKey));
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
