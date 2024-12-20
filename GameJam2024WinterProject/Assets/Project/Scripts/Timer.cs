using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	[SerializeField]
	private TMPro.TMP_Text text;

	private float time;

	// Start is called before the first frame update
	void Start() {
		time = 0.0f;
	}

	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;

		int second = (int)time;
		int sentiSecont = (int)(time * 100) % 100;

		text.SetText("<size=70>" + second + "</size>." + sentiSecont);
	}
}
