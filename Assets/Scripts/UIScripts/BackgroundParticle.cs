using System.Collections;
using UnityEngine;

public class BackgroundParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private int _colorsNumber;
    private Colors _colors;

    private void Start() =>
        StartCoroutine(ChangeParticleColor());

    private IEnumerator ChangeParticleColor()
    {
        _colors = new Colors();
        while (true)
        {
            _colorsNumber = Random.Range(0, 5);
            _particleSystem.startColor = _colors.colorsDict[_colorsNumber];
            yield return new WaitForSeconds(2);
        }
    }
}
