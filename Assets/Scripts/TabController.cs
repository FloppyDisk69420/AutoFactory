using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabController : MonoBehaviour {
	[SerializeField] public Image icon;
	[SerializeField] public TMP_Text text;
	[SerializeField] public Image image;
	[SerializeField] public Image close;

	[SerializeField] public Sprite[] icons;

	public void UpdateTab(GameObject file) {
		text.text = file.GetComponent<FileController>().fileName;
		switch (file.GetComponent<FileController>().fileType) {
			case FileController.FileType.CSharp:
				icon.sprite = icons[(int)FileController.FileType.CSharp]; 
			break;
			case FileController.FileType.CPlus: 
				icon.sprite = icons[(int)FileController.FileType.CPlus]; 
			break;
			case FileController.FileType.Javascript:
				icon.sprite = icons[(int)FileController.FileType.Javascript]; 
			break;
		}
	}

	public void UpdateTab(string fileName, FileController.FileType fileType) {
		text.text = fileName;
		switch (fileType) {
			case FileController.FileType.CSharp:
				icon.sprite = icons[(int)FileController.FileType.CSharp]; 
			break;
			case FileController.FileType.CPlus: 
				icon.sprite = icons[(int)FileController.FileType.CPlus]; 
			break;
			case FileController.FileType.Javascript:
				icon.sprite = icons[(int)FileController.FileType.Javascript]; 
			break;
		}
	}

	public void UpdatePosition(int index) {
		RectTransform rt = GetComponent<RectTransform>();
		rt.localScale = Vector3.one;
		rt.SetLeft(0);
		rt.SetRight(0);
		rt.SetTop(0);
		rt.SetBottom(0);
		rt.anchorMin = new Vector2(0.15f * index, 0);
		rt.anchorMax = new Vector2(0.15f + 0.15f * index, 1);
	}

	public void OnActivate() {
		image.color = new Color32(0, 20, 31, 255);
		text.color = new Color32(220, 220, 220, 255);
		icon.color = new Color32(255, 255, 255, 255);
		close.color = new Color32(255, 255, 255, 255);
	}
	public void OnDeactivate() {
		image.color = new Color32(0, 0, 23, 255);
		text.color = new Color32(106, 106, 106, 255);
		icon.color = new Color32(140, 140, 140, 255);
		close.color = new Color32(200, 200, 200, 255);
	}
}