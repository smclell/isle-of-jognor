using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_Interactions : MonoBehaviour
{
    private Outline outline;

    
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
