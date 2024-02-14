using UnityEngine;

public class InterUIControl : MonoBehaviour
{
    [SerializeField] private Canvas interCanvas;

    public void InterUIOff()
    {
        interCanvas.enabled = false;
    }
}
