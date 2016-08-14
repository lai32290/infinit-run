using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && sceneName != "")
            Application.LoadLevel(sceneName);
	}
}
