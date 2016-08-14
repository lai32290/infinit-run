using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

    public GameObject Player;
    public float moveSpeed;
    private float x;
    private bool scored;
    
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;
        x += moveSpeed * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y);

        if (x < -7)
            Destroy(transform.gameObject);

        if (!scored && x < Player.transform.position.x)
        {
            scored = true;
            PlayerController.score++;
        }

	}
}
