using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text recordText;
    public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
        recordText.text = PlayerPrefs.GetInt("record").ToString();
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
