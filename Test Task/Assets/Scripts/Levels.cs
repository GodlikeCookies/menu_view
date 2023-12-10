using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public static int completedLevels = 0;
    private List<GameObject> levelButtons = new List<GameObject>();
    private void Start()
    {
        levelButtons.Clear();
        for (int i = 0; i < ObjectsContainer.levelsViewCanvas.GetChild(0).childCount; i++)
            if (ObjectsContainer.levelsViewCanvas.GetChild(0).GetChild(i).GetComponent<Button>())
                levelButtons.Add(ObjectsContainer.levelsViewCanvas.GetChild(0).GetChild(i).gameObject);
        CheckLevelCompletness();
    }
    private void CheckLevelCompletness()
    {
        foreach (var button in levelButtons)
        {
            if (levelButtons.IndexOf(button) <= completedLevels)
            {
                button.transform.GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                button.transform.GetChild(0).gameObject.SetActive(false);
                button.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        levelButtons[completedLevels].GetComponent<Button>().onClick.AddListener(CompleteLevel);
    }
    public void Open()
    {
        ObjectsContainer.menuViewCanvas.gameObject.SetActive(false);
        ObjectsContainer.levelsViewCanvas.gameObject.SetActive(true);
        ObjectsContainer.mainCamera.gameObject.SetActive(false);
        ObjectsContainer.levelsCamera.gameObject.SetActive(true);
    }
    public void Close()
    {
        ObjectsContainer.menuViewCanvas.gameObject.SetActive(true);
        ObjectsContainer.levelsViewCanvas.gameObject.SetActive(false);
        ObjectsContainer.mainCamera.gameObject.SetActive(true);
        ObjectsContainer.levelsCamera.gameObject.SetActive(false);
    }
    void CompleteLevel()
    {
        levelButtons[completedLevels].GetComponent<Button>().onClick.RemoveListener(CompleteLevel);
        completedLevels++;
        Debug.Log($"Level {completedLevels} completed");
        CheckLevelCompletness();
        Shop.UpdateItems();
    }
}
