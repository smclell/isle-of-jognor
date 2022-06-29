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
        Key,
        End
    }

    public ClueType clueType;
    public bool found;
    public string clueInfo;

    public void addInfo(List<string> names, List<string> locations, bool needKey)
    {
        //change into switch case to modify for each type of clue
        switch (clueType.ToString())
        {
            case "Object":
                clueInfo = "An object found at " + locations[0] + ". It was owned by " + names[1] + ", this might be helpful if you take it to " + locations.Last();
                if (needKey)
                {
                    clueInfo += ", you might need a key to get in.";
                }
                else
                {
                    clueInfo += ".";
                }
                break;
            case "Blood":
                clueInfo = "The blood you found at " + locations[0] + " seems to belong to " + names[1] + ". Look around to see if you can find more hints about it.";
                break;
            case "Key":
                clueInfo = "This key seems to be for a lock at " + locations.Last() + ". Take it there to see if you can open up something.";
                break;
            case "End":
                clueInfo = names.Last();
                break;
            default:
                clueInfo = "N/A";
                break;
        }
    }

    public void toggleClue(bool active)
    {
        found = active;
    }
}
