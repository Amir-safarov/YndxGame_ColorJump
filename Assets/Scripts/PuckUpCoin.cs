using UnityEngine;
public class PuckUpCoin : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _spawnColider;
    [SerializeField] private PlayerMove _player;

    private float _xSpawnRange;
    private float _ySpawnRange;
    private bool _needSpawn = true;
    private void Start()
    {
        GlobalEventManager.CoinRespawnEvent.AddListener(Spawn);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            _needSpawn = true;
            transform.gameObject.SetActive(false);
        }
    }
}
