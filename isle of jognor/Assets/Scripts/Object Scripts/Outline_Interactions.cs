using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_Interactions : MonoBehaviour
{
    private Outline outline;

    [SerializeField, Range(0, 3)] public int relatedQuest;

    [SerializeField, Range(0, 2)] public int relatedClue;

    public int RelatedClue { get => relatedClue; set => relatedClue = value; }
    public int RelatedQuest { get => relatedQuest; set => relatedQuest = value; }


    //[SerializeField, Range(0f, 20f)]
    //private float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        outline.enabled = false;
    }

}
