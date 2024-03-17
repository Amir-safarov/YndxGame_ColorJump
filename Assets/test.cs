using System.Collections;
using UnityEditor;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform objectToFollow;
    public LineRenderer lineRenderer;

    private bool isVisible;

    void Start()
    {
        StartCoroutine(DisappearAfterDelay(0.02f));
    }

    void Update()
    {
        if (objectToFollow != null)
        {

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, objectToFollow.position);
        }
    }

    IEnumerator DisappearAfterDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            isVisible = !isVisible;
            lineRenderer.enabled = isVisible; 
        }
    }
}
