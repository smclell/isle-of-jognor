using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private Outline outline;


    [SerializeField, Range(0f, 20f)]
    private float maxDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        //outline.enabled = false;
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
        }
        else
        {
            outline = hit.collider.gameObject.GetComponent<Outline>();
            outline.enabled = false;
        }
    }
}
