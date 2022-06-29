using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest
{
    public List<Clue> clueList;
    public string questInfo;
    public string questTitle;
    public List<string> involved;
    public List<string> locations;
    public int numClues;
    public bool started;
    public bool needKey;
    public bool finished = false;

    public Quest(string title, string info, int clues, bool needKey)
    {
        clueList = new List<Clue>();
        involved = new List<string>();
        locations = new List<string>();

        this.questInfo = info;
        this.questTitle = title;
        this.numClues = clues;
        this.started = false;
        this.needKey = needKey;

        for (int i = 0; i < numClues; i++)
        {
            addClue(new Clue { found = false, clueInfo = "" });
        }
    }

    public void addClue(Clue clue) {
        //Debug.Log(this.questInfo);
        //Debug.Log(this.locations.ToString());

        clueList.Add(clue);
    }

    public void addClueInfo()
    {
        foreach (Clue clue in clueList)
        {
            clue.addInfo(this.involved, this.locations, needKey);
        }
    }

    public void addInvolved(string person)
    {

        involved.Add(person);
    }

    public void addLocation(string location)
    {
        locations.Add(location);
    }

    public void activateQuest()
    {
        this.started = true;
    }

    public void deactivateQuest()
    {
        this.started = false;
    }
}
