using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_Interactions : MonoBehaviour
{
    private Renderer render;

    private Outline outline;

    [SerializeField, Range(0f, 5f)]
    private float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
        render = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (render.isVisible)
        {
            StartCoroutine(Outline());
        }
        else
        {
            outline.enabled = false;
        }
    }

    IEnumerator Outline()
    {
        yield return new WaitForSeconds(waitTime);

        outline.enabled = true;
    }


}
