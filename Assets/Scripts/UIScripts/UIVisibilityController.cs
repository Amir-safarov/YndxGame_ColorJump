using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class UIVisibilityController : MonoBehaviour
{
    [SerializeField] private bool _isCheckingOnAuth;
    [SerializeField] private GameObject _object;
    [SerializeField] private HighlightObject _highlightObj;

    public void ObjectOn()
    {

        if (!_isCheckingOnAuth)
            _object.SetActive(true);
        else
        {
            if (YandexGame.auth && YandexGame.SDKEnabled)
                _object.SetActive(true);
            else
                _highlightObj.StartHighlight();
        }
    }

    public void ObjectOff()
    {
        _object.SetActive(false);
    }
}
