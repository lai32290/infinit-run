using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public GameObject prefabObject;
    public float rateSpawn;

    public float altura1;
    public float altura2;

    private float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = 0;
	}

    // Update is called once per frame
    void Update() {
        currentTime += Time.deltaTime;

        if (currentTime >= rateSpawn)
        {
            currentTime = 0;

			float y = Random.Range(1, 100) % 2 == 0 ? altura1 : altura2;

            GameObject wall = Instantiate(prefabObject) as GameObject;
            wall.transform.position = new Vector3(transform.position.x, y);
        }


	}
}
