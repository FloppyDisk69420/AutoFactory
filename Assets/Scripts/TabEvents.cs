using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabEvents : MonoBehaviour {
	[SerializeField]
	public GameObject tabPrefab;
	[SerializeField]
	public GameObject tabCollection;
	private List<GameObject> tabs;
	private int tabSelectedIndex;

	void Start() {
		tabs = new List<GameObject>();
		tabSelectedIndex = 0;
	}
	// make it so that there cant be duplicates TODO
    GameObject CreateTab(TMP_Text fileName, FileController.FileType fileType) {
		GameObject tab = Instantiate(tabPrefab);

		tab.name = fileName.text;
		tab.transform.SetParent(tabCollection.transform);

		string tabName = "";
		switch (fileType) {
			case FileController.FileType.CSharp:
				tabName = fileName.text + ".cs";
			break;
			case FileController.FileType.CPlus:
				tabName = fileName.text + ".cpp";
			break;
			case FileController.FileType.Javascript:
				tabName = fileName.text + ".js";
			break;
		}
		TabController tc = tab.GetComponent<TabController>();
		tc.UpdatePosition(tabs.Count);
		tab.GetComponent<Button>().onClick.AddListener(() => {
			OpenTab(tc);
		});
		tab.transform.Find("CloseTab").GetComponent<Button>().onClick.AddListener(() => {
			CloseTab(tab);
		});
		
		tc.UpdateTab(tabName, fileType);
		tc.OnActivate();
		AddTabToList(tab);
		return tab;
	}

	void AddTabToList(GameObject tab) {
		tabs.Add(tab);
	}

	public void OpenTab(GameObject file) {
		GameObject selectedTab = null;
		foreach (GameObject tab in tabs) {
			if (tab.name == file.name) {
				tab.GetComponent<TabController>().OnActivate();
				selectedTab = tab;
			}
			else {
				tab.GetComponent<TabController>().OnDeactivate();
			}
		}
		if (selectedTab == null) {
			selectedTab = CreateTab(file.GetComponent<FileController>().fileTMP, file.GetComponent<FileController>().fileType);
		}
		tabSelectedIndex = tabs.FindIndex(new System.Predicate<GameObject>((e) => {
			return e == selectedTab;
		}));
	}

	public void OpenTab(TabController tc) {
		foreach (GameObject tab in tabs) {
			tab.GetComponent<TabController>().OnDeactivate();
		}
		tc.OnActivate();
		tabSelectedIndex = tabs.FindIndex(new System.Predicate<GameObject>((e) => {
			return e.GetComponent<TabController>() == tc;
		}));
	}

	public void CloseTab(GameObject closeTab) {
		tabs.Remove(closeTab);
		Destroy(closeTab);
		for (int i = 0; i < tabs.Count; i++) {
			tabs[i].GetComponent<TabController>().UpdatePosition(i);
		}
		if (tabs.Count != 0) {
			if (tabSelectedIndex > tabs.Count - 1) {
				OpenTab(tabs[tabs.Count - 1].GetComponent<TabController>());
			}
			OpenTab(tabs[tabSelectedIndex].GetComponent<TabController>());
		}
	}
}