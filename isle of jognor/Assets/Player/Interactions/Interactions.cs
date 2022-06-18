using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private Outline outline;


    [SerializeField, Range(0f, 20f)]
    private float maxDistance = 10f;

    [SerializeField] private UI_Inventory uiInventory;


    private QuestList quests;

    // Start is called before the first frame update
    void Start()
    {
        quests = new QuestList();
        uiInventory.setQuestList(quests);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Creates a Ray from the center of the viewport
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Interactable Clue"))
        {
            outline = hit.collider.gameObject.GetComponent<Outline>();
            outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                int questNum = hit.collider.gameObject.GetComponent<Outline_Interactions>().RelatedQuest;
                int clueNum = hit.collider.gameObject.GetComponent<Outline_Interactions>().RelatedClue;

                //quests.questList[questNum].activateQuest();
                quests.questList[questNum].clueList[clueNum].toggleClue(true);

                hit.collider.gameObject.GetComponent<Renderer>().enabled = false;

                uiInventory.RefreshQuestList();
            }
        } else if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject.CompareTag("Quest Giver"))
        {
            outline = hit.collider.gameObject.GetComponent<Outline>();
            outline.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                int questNum = hit.collider.gameObject.GetComponent<Outline_Interactions>().RelatedQuest;
                //int clueNum = hit.collider.gameObject.GetComponent<Outline_Interactions>().RelatedClue;

                quests.questList[questNum].activateQuest();
                //quests.questList[questNum].clueList[clueNum].toggleClue(true);

                //hit.collider.gameObject.GetComponent<Renderer>().enabled = false;

                uiInventory.RefreshQuestList();
            }
        }


        if (Input.GetKeyUp(KeyCode.Tab))
        {
            uiInventory.enabled = !uiInventory.enabled;
        }
    }
}
