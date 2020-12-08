using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {
	public GameObject blueprinter;
	public GameObject codeEditor;

	void Start() {
		codeEditor.SetActive(false);
		blueprinter.SetActive(false);
	}

	public void ActivateBlueprinterUI() {
		blueprinter.SetActive(true);
		codeEditor.SetActive(false);
		Debug.Log("Activating Blueprinter...");
	}

	public void ActivateCodeEditorUI() {
		blueprinter.SetActive(false);
		codeEditor.SetActive(true);
		Debug.Log("Activating Code Editor...");
	}
}
