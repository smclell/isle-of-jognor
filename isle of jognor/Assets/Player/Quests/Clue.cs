using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Clue
{
    public enum ClueType
    {
        Blood,
        Object,
        Key
    }

    public ClueType clueType;
    public bool found;
    public string clueInfo;

    public void addInfo(List<string> names, List<string> locations)
    {
        //change into switch case to modify for each type of clue
        clueInfo = "A(n) " + clueType.ToString() + " found at " + locations[0] + ". This was owned by " + names[1] + ", this might be helpful if you take it to " + locations.Last() + ".";
    }

    public void toggleClue(bool active)
    {
        found = active;
    }
}
