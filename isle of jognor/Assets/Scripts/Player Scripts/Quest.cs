using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest
{
    public List<Clue> clueList;
    public string questInfo;
    public List<string> involved;
    public List<string> locations;

    public Quest() {
        clueList = new List<Clue>();
        involved = new List<string>();
        locations = new List<string>();

        addClue(new Clue { clueType = Clue.ClueType.Object, found = false, clueInfo = "" });

    }

    public void addClue(Clue clue) {
        //Debug.Log(this.questInfo);
        //Debug.Log(this.locations.ToString());

        clueList.Add(clue);
    }

    public void addClueInfo()
    {
        //Debug.Log(this.questInfo);

        clueList.Last().addInfo(this.involved, this.locations);
    }

    public void addInvolved(string person)
    {

        involved.Add(person);
    }

    public void addLocation(string location)
    {
        locations.Add(location);
    }
}
