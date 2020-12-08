using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEditorController : MonoBehaviour {
    [SerializeField]
	public GameObject addon;
	[SerializeField]
	public GameObject fileManager;
	[SerializeField]
	public GameObject createFileForm;
	[SerializeField]
	public GameObject fileContents;
	[SerializeField]
	public GameObject fileLibrary;
	[SerializeField]
	public GameObject filePrefab;
	
	[SerializeField]
	public TMP_InputField fileName;
	[SerializeField]
	public TMP_Dropdown fileType;

	private int fileNum;

	void Start() {
		addon.SetActive(true);
		fileManager.SetActive(true);
		createFileForm.SetActive(false);
		fileNum = 0;
	}

	public void ToggleAddon() {
		addon.SetActive(!addon.activeSelf);
		if (addon.activeSelf) {
			fileContents.GetComponent<RectTransform>().anchorMin = new Vector2(0.1311919f, 0f);
		}
		else {
			fileContents.GetComponent<RectTransform>().anchorMin = new Vector2(0.03378993f, 0f);
		}
	}
	public void ToggleFileManager() {
		fileManager.SetActive(!fileManager.activeSelf);
	}

	public void ActivateNewFileForm() {
		createFileForm.SetActive(true);
	}
	public void DeactivateNewFileForm() {
		createFileForm.SetActive(false);
	}

	public void CreateFile() {
		GameObject newFile = Instantiate(filePrefab);

		newFile.GetComponent<FileController>().fileName = fileName.text;
		switch (fileType.captionText.text) {
			case "C#":
				newFile.GetComponent<FileController>().fileType = FileController.FileType.CSharp;
			break;
			case "C++":
				newFile.GetComponent<FileController>().fileType = FileController.FileType.CPlus;
			break;
			case "Javascript":
				newFile.GetComponent<FileController>().fileType = FileController.FileType.Javascript;
			break;
		}

		newFile.transform.SetParent(fileLibrary.transform);
		newFile.name = fileName.text;
		RectTransform rt = newFile.GetComponent<RectTransform>();
		rt.localScale = Vector3.one;
		rt.SetLeft(0);
		rt.SetRight(0);
		rt.SetTop(0);
		rt.SetBottom(0);
		rt.anchorMin = new Vector2(0f, 0.96f - 0.05f * fileNum);
		rt.anchorMax = new Vector2(1f, 1f - 0.05f * fileNum);

		newFile.GetComponent<Button>().onClick.AddListener(() => {
			GetComponent<TabEvents>().OpenTab(newFile);
		});

		fileNum++;
	}
}
