using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Utility;

public class MainPanel : MonoBehaviour {

	private AsyncOperation operation = null;

	// Use this for initialization
	void Start () {
		Button btn = transform.Find ("enterSceneBtn").GetComponent<Button>();
		btn.onClick.AddListener (onEnterScenBtn);
		//SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
	}
	
	// Update is called once per frame
	void Update () {
		if (operation == null) {
			return;
		}
		if (operation.progress > 0.899999f) {
			operation.allowSceneActivation = true;
		}
	}

	private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
	{
        SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;

        var prefab = Resources.Load ("Standard Assets/Characters/ThirdPersonCharacter/Prefabs/ThirdPersonController", typeof(GameObject));
		GameObject instance = Instantiate(prefab, new Vector3 (250, 0, 249), Quaternion.identity) as GameObject;

		Camera.main.gameObject.AddComponent<SmoothFollow> ();
		Camera.main.GetComponent<SmoothFollow> ().target = instance.transform;
		Camera.main.fieldOfView = 35.0f;

		prefab = Resources.Load ("UI/Widgets/JoystickWidget", typeof(GameObject));
		instance = Instantiate(prefab) as GameObject;
		instance.transform.SetParent (FindObjectOfType<Canvas> ().transform);
	}

	public void onEnterScenBtn()
	{
        //StartCoroutine(load ());
        LoadingScenePanel.show("");

    }

	private IEnumerator load()
	{
		operation =	SceneManager.LoadSceneAsync ("Scenes/SecondScene");
		operation.allowSceneActivation = false;
		while (!operation.isDone) {
			yield return null;
		}
	}



}
