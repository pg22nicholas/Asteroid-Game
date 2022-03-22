using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float m_spawnTimeMin = 0.5f;
    [SerializeField] private float m_spawnTimeMax = 3f;
    [SerializeField] private float m_radius = 30f;

    //[SerializeField] private Projectile m_asteroid;
    [SerializeField] private List<Asteroid> m_asteroids = new List<Asteroid>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomSpawnDelay());
            SpawnAsteroid();
        }

        // yield break; // End coroutine once hit - stub in code
    }

    private float GetRandomSpawnDelay()
    {
        return Random.Range(m_spawnTimeMin, m_spawnTimeMax);
    }

    private void SpawnAsteroid()
    {
        //Debug.Log("Asterioid spawned");
        Vector3 spawnPosition = GetRandomSpawnPoint(m_radius);
        Vector3 endPosition = GetRandomSpawnPoint(m_radius);

        if (m_asteroids.Count == 0)
            return;

        Asteroid spawnAsteroid = m_asteroids[Random.Range(0, m_asteroids.Count)];

        var astroid = Instantiate(spawnAsteroid, spawnPosition, Quaternion.identity);
        astroid.transform.LookAt(endPosition);
    }

    private Vector3 GetRandomSpawnPoint(float radius)
    {
        Vector2 point2d = Random.insideUnitCircle.normalized * radius;
        Vector3 point3d = new Vector3(point2d.x, 0f, point2d.y);
        return point3d;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }

}
