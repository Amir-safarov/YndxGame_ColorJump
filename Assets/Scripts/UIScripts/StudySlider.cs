using UnityEngine;
using UnityEngine.UI;

public class StudySlider : MonoBehaviour
{
    [SerializeField] private Transform _slidesParent;
    [SerializeField] private ShopsController _controller;
    [SerializeField] private Button _button;

    private int _maxClicks;
    private int _clickCount;

    private void Awake()
    {
        _maxClicks = _slidesParent.childCount;
        _clickCount = 1;
        ControlParentsChildren(false);
        ControlParentsChildren(true,0);
    }

    public void NextSlide()
    {
        if (_clickCount >= _maxClicks)
        {
            _controller.ShopOff();
            _clickCount = 1;
            ControlParentsChildren(false);
            ControlParentsChildren(true, 0);
            return;
        }
        ControlParentsChildren(true, _clickCount);
        _clickCount++;
    }

    private void ControlParentsChildren(bool switcher)
    {
        for (int i = 0; i < _slidesParent.childCount; i++)
            _slidesParent.GetChild(i).gameObject.SetActive(switcher);
    }
    private void ControlParentsChildren(bool switcher, int childIndex)
    {
        _slidesParent.GetChild(childIndex).gameObject.SetActive(switcher);
    }
}
