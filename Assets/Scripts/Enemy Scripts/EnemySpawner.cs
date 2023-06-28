using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int maxEnemies;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float spawnInterval;

        private int _currentEnemies;

        private void Start()
        {
            StartSpawning();
        }

        private void StartSpawning()
        {
            InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
        }

        private void SpawnEnemy()
        {
            if (_currentEnemies >= maxEnemies)
                return;

            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
            _currentEnemies++;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            Vector2 randomCirclePoint = Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);
            return spawnPosition;
        }

        public void EnemyDied()
        {
            _currentEnemies--;
        }
    }
}