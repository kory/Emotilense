using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GenEmotion : MonoBehaviour {

    GameObject last;

	// Use this for initialization
	void Start ()
    {
		
	}

	// Update is called once per frame
    // creates a 3D text at the top of each person's head with emotion corresponding to their facial expression
	void Update(ObjectInfo[] allInfo)
    {
        for(int i = 0; i < allInfo.Length; i++)
        {
            ObjectInfo info = allInfo[i];
            // 100 is arbitrary
            Vector3 vector = new Vector3(info.Left, info.Top, 100 - info.Height);
            GameObject text = new GameObject();
            text.AddComponent<TextMesh>();
            text.AddComponent<MeshRenderer>();
            text.transform.position = vector;
            text.GetComponent<TextMesh>().text = info.Emotion;
            Destroy(last);
            last = text;
        }
    }
}
