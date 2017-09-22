using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        LoadingScenePanel.show("");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
