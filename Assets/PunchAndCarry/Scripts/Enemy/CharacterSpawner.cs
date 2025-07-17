using UnityEngine;
using UnityEngine.Pool;

namespace PunchAndCarry.Scripts.Enemy
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyController _prefab;
        [SerializeField] private float _spawnInterval = 2;

        private IObjectPool<EnemyController> _pool;

        private bool _isSpawning = true;
        
        void Start()
        {
            _pool = new ObjectPool<EnemyController>(
                CreateEnemy,
                OnSpawnEnemy,
                OnReleaseEnemy,
                OnDestroyEnemy);
            
            SpawnLoop();
        }

        private void OnDestroyEnemy(EnemyController enemy)
        {
            Destroy(enemy.gameObject);
        }

        private void OnReleaseEnemy(EnemyController enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private void OnSpawnEnemy(EnemyController enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        private EnemyController CreateEnemy()
        {
            return Instantiate(_prefab);
        }

        private async void SpawnLoop()
        {
            while (_isSpawning)
            {
                Vector3 spawnPoint = Vector3.zero;
                spawnPoint.x = Random.Range(-6f, 6f); 
                spawnPoint.z = Random.Range(-6f, 6f); 
                var enemy = _pool.Get();
                enemy.transform.position = spawnPoint;
                
                await Awaitable.WaitForSecondsAsync(_spawnInterval);
            }
        }

        public void StopSpawning()
        {
            _isSpawning = false;
        }
    }
}
