using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        SpawnEnemyShips();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemyShips()
    {
                
        GameObject enemies = new GameObject("Enemies");
        for (int i = 0; i < 20; i++){
            Vector3 where = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F), 0);
            GameObject what = enemyPrefab;
            Quaternion whatRotation = Quaternion.identity;
            GameObject enemy = (GameObject)Instantiate(what, where, whatRotation);
            enemy.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), 0, 0, 1);
            enemy.transform.parent = enemies.transform;
            enemy.name = "Enemy" + i;
        }
    }
}
