using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    void Start(){
        EventManager.EnemyDieEvent += OnEnemyDie;
    }

    public IEnumerator SpawnRandom() {
        while (true) {
            GameObject prefab = EnemyPrefabs[Random.Range(0,EnemyPrefabs.Length)];
            Vector2 pos = Points.points[Random.Range(0,Points.points.Count)].GetPos();

            SpawnEnemy(prefab, pos);

            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnEnemy(GameObject prefab, Vector3 position){
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
        enemy.GetComponent<Enemy>().Move();
    }

    void OnEnemyDie(){
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-4.5f, 4.5f);
        Point point = new Point(x, y);

        Points.points.Add(point);
    }
}
