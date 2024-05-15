using UnityEngine;

public class AT : MonoBehaviour
{
    [System.Obsolete]
    private void Awake()
    {
        GlobalEventManager.OnSideColorChange.AddListener(UpdateSideTheme);
    }

    [System.Obsolete]
    private void UpdateSideTheme(string code)
    {
        Application.ExternalCall("SetColor", code);
        print($"Side color pick {code}");
    }
}
