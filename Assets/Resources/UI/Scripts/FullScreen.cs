using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour {
	// Use this for initialization
	void Start () {
		var tr = (RectTransform)transform;
		float scale = Screen.width / tr.rect.size.x;
		transform.localScale = new Vector3(scale, scale, 0);
        resetBackgroundImgage();

    }

	void resetBackgroundImgage()
	{
        Transform trans = transform.Find("FSBackground");
        if (trans == null)
        {
            return;
        }
        
        GameObject obj = trans.gameObject;

        var oldSize = ((RectTransform)obj.transform).rect.size;
        var scale = Mathf.Max(Screen.width / oldSize.x, Screen.height / oldSize.y);
        scale /= transform.localScale.x;
        obj.transform.localScale = new Vector3 (scale / obj.transform.localScale.x, scale / obj.transform.localScale.y, 1);

        Debug.Log(obj.transform.localScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
