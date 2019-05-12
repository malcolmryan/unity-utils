using UnityEngine;
using System.Collections;

namespace WordsOnPlay.Utils {

[System.Serializable]
public class Button {
	public string name;
	bool pressed = false;

	public bool Pressed {
		get { return pressed; }
	}

	bool released = false;

	public bool Released {
		get { return released; }
	}

	public float clearTime = 0.2f;
	private float clear = 0;

	public Button(string name) {
		this.name = name;
	}

	public void Check() {
		if (clear > 0) {
			clear -= Time.deltaTime;
			if (clear < 0) {
				pressed = false;
			}
		} 

		if (Input.GetButtonDown(name)) {
			pressed = true;
			released = false;
			clear = clearTime;
		}
		
		if (Input.GetButtonUp(name)) {
			released = true;
		}
	}
}


}

