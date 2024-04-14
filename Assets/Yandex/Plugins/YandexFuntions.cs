using System.Runtime.InteropServices;
using UnityEngine;

public class YandexFuntions : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    private void TestFunction()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Hello();
    }
    private void Update()
    {
        TestFunction();
    }
}
