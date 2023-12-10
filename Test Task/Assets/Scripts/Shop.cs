using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private static List<ShopItem> itemCharacter = new List<ShopItem>()
    {
        new ShopItem("[Character 1]", null, 0),
        new ShopItem("[Character 2]", null, 10),
    };
    private static List<ShopItem> itemLocation = new List<ShopItem>()
    {
        new ShopItem("[Location 1]", null, 0),
        new ShopItem("[Location 2]", null, 0),
        new ShopItem("[Location 3]", null, 10),
    };

    private void Start()
    {
        foreach (var item in itemCharacter)
        {
            item.obj = GameObject.Instantiate(PlacebleObjectsData.LoadFromAssets().shopItemTickets, ObjectsContainer.shopViewCanvas.GetChild(0).GetChild(0).GetChild(2).transform);
            item.obj.transform.GetChild(0).GetComponent<Text>().text = item.name;
            item.obj.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = $"LV. {item.openLevel}";
            item.obj.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "500";
        }
        foreach (var item in itemLocation)
        {
            item.obj = GameObject.Instantiate(PlacebleObjectsData.LoadFromAssets().shopItemTickets, ObjectsContainer.shopViewCanvas.GetChild(0).GetChild(0).GetChild(3).transform);
            item.obj.transform.GetChild(0).GetComponent<Text>().text = item.name;
            item.obj.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = $"LV. {item.openLevel}";
            item.obj.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "500";
        }
        UpdateItems();
    }
    public static void UpdateItems()
    {
        foreach (var item in itemCharacter)
        {
            if (Levels.completedLevels >= item.openLevel) UpdateData(item, true);
            else UpdateData(item, false);
        }
        foreach (var item in itemLocation)
        {
            if (Levels.completedLevels >= item.openLevel) UpdateData(item, true);
            else UpdateData(item, false);
        }
    }
    private static void UpdateData(ShopItem item, bool isConditionCompleted)
    {
        if (isConditionCompleted)
        {
            item.obj.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            item.obj.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            item.obj.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            item.obj.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
            item.obj.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { BuyForTickets(item.obj, item.name); });
        }
        else
        {
            if (!item.obj.transform.GetChild(2).GetChild(2).gameObject.activeSelf)
            {
                item.obj.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                item.obj.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
                item.obj.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
        }
    }
    public void Open()
    {
        ObjectsContainer.mainCamera.SetActive(false);
        ObjectsContainer.menuViewCanvas.gameObject.SetActive(false);
        ObjectsContainer.shopCamera.SetActive(true);
        ObjectsContainer.shopViewCanvas.gameObject.SetActive(true);
    }
    public void Close()
    {
        ObjectsContainer.mainCamera.SetActive(true);
        ObjectsContainer.menuViewCanvas.gameObject.SetActive(true);
        ObjectsContainer.shopCamera.SetActive(false);
        ObjectsContainer.shopViewCanvas.gameObject.SetActive(false);
    }
    private static void BuyForTickets(GameObject obj, string id)
    {
        if (Tickets.count < 500) return;
        obj.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
        Tickets.count -= 500;
        Debug.Log($"{id} bought");
        obj.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        obj.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        obj.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        UpdateItems();
    }
}
public class ShopItem
{
    public string name;
    public GameObject obj;
    public int openLevel;

    public ShopItem(string name, GameObject obj, int openLevel)
    {
        this.name = name;
        this.obj = obj;
        this.openLevel = openLevel;
    }
}

