using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject airEnemyPrefabs;
    [SerializeField] int airEnemyCount;
    public List<GameObject> airEnemyList;
    private MainManager mainManager;
    private float zRange = 250f;
    private float xRange = 250f;
    private float yRangeDown = 20f;
    private float yRangeUp = 60f;

    // Start is called before the first frame update
    void Start()
    {
        EnemyPool();
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        StartCoroutine(EnemySpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyPool()
    {
        for (int i = 0; i < airEnemyCount; i++)
        {
            var airEnemy = Instantiate(airEnemyPrefabs);
            airEnemy.SetActive(false);
            airEnemy.transform.SetParent(this.transform);
            airEnemyList.Add(airEnemy);
        }
    }

    private GameObject GetAirEnemy()
    {
        foreach(GameObject enemy in airEnemyList)
        {
            if(!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    private void EnemyAirSpawn()
    {
        Debug.Log("Spawn");
        var airEnemy = GetAirEnemy();
        if(airEnemy != null)
        {
            var pos = new Vector3(Random.Range(-xRange, xRange), Random.Range(yRangeDown, yRangeUp), Random.Range(-zRange, zRange));
            if (SpawnRestrictionArea.instance.IsRestrictionArea(pos))
            {
                airEnemy.SetActive(true);
                airEnemy.transform.position = pos;
            }
        }
    }

    IEnumerator EnemySpawnCoroutine()
    {
        while(mainManager.isGameActive)
        {
            yield return new WaitForSeconds(3);
            EnemyAirSpawn();
        }
    }
}
