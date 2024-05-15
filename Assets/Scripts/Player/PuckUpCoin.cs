using UnityEngine;

public class PuckUpCoin : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _spawnColider;
    [SerializeField] private PlayerMove _player;
    [SerializeField] private CoinsValue _putOn;

    private float _xSpawnRange;
    private float _ySpawnRange;
    private bool _needSpawn;

    private void Start()
    {
        ResetState();
        GlobalEventManager.CoinRespawnEvent.AddListener(Spawn);
        _putOn.ActivateCoinsPutOn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            GlobalEventManager.SendToCoinReceive();
            _needSpawn = true;
            transform.gameObject.SetActive(false);
        }
    }

    public void ResetState()
    {
        _needSpawn = true;
        transform.gameObject.SetActive(false);
    }

    private void Spawn()
    {
        if (_needSpawn)
        {
            transform.gameObject.SetActive(true);
            _xSpawnRange = Random.Range(_spawnColider.bounds.min.x, _spawnColider.bounds.max.x);
            _ySpawnRange = Random.Range(_spawnColider.bounds.min.y, _spawnColider.bounds.max.y);
            transform.position = new Vector2(Mathf.Round(_xSpawnRange), Mathf.Round(_ySpawnRange));
        }
        _needSpawn = false;
    }
}
