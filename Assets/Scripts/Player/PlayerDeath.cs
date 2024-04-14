using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playersParticleSystem;
    [SerializeField] private PlayerMove _player;

    private SpriteRenderer _sp;

    [System.Obsolete]
    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        GlobalEventManager.PlayerDeadEvent.AddListener(ActivateDeath);
    }

    [System.Obsolete]
    private void ActivateDeath()
    {
        StartCoroutine(Death());
    }

    [System.Obsolete]
    private IEnumerator Death()
    {
        _player.BlockMove();
        PlayParticle();
        _sp.enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        StopParticle();
        GlobalEventManager.ActivateRestarMenu();
        _sp.enabled = true;
    }

    [System.Obsolete]
    private void PlayParticle()
    {
        _playersParticleSystem.textureSheetAnimation.RemoveSprite(0);
        _playersParticleSystem.textureSheetAnimation.AddSprite(_sp.sprite);
        _playersParticleSystem.startColor = _sp.color;
        _playersParticleSystem.Play();
    }

    private void StopParticle()
    {
        _playersParticleSystem.Stop();
    }
}
