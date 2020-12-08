using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileController : MonoBehaviour
{
	public enum FileType { CSharp, CPlus, Javascript };
	[SerializeField] public string fileName;
	[SerializeField] public FileType fileType;
	[SerializeField] public TMP_Text fileTMP;
	[SerializeField] public Image fileIcon; 

	[SerializeField] public Sprite[] icons;

	void Start() {
		if (fileName == "" || fileName == null) {
			fileName = "Unnamed file";
		}
		fileTMP.text = fileName;
		switch (fileType) {
			case FileType.CSharp:         fileIcon.sprite = icons[(int)FileType.CSharp]; break;
			case FileType.CPlus:          fileIcon.sprite = icons[(int)FileType.CPlus]; break;
			case FileType.Javascript:     fileIcon.sprite = icons[(int)FileType.Javascript]; break;
			default:                      fileIcon.sprite = icons[(int)FileType.CSharp]; break;
		}
	}

	void UpdateFile() {
		fileTMP.text = fileName;
		switch (fileType) {
			case FileType.CSharp:         fileIcon.sprite = icons[(int)FileType.CSharp]; break;
			case FileType.CPlus:          fileIcon.sprite = icons[(int)FileType.CPlus]; break;
			case FileType.Javascript:     fileIcon.sprite = icons[(int)FileType.Javascript]; break;
			default:                      fileIcon.sprite = icons[(int)FileType.CSharp]; break;
		}
	}
}
