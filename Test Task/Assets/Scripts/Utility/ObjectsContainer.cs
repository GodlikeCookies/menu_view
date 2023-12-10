using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsContainer : MonoBehaviour
{
    public static GameObject audioManager;

    public static GameObject mainCamera;
    public static GameObject shopCamera;
    public static GameObject levelsCamera;

    public static Transform menuViewCanvas;
    public static Transform shopViewCanvas;
    public static Transform levelsViewCanvas;

    private void Awake()
    {
        mainCamera = GameObject.Find("MenuViewCamera");
        shopCamera = GameObject.Find("ShopViewCamera");
        levelsCamera = GameObject.Find("LevelsViewCamera");
        menuViewCanvas = GameObject.Find("MenuViewCanvas").transform;
        shopViewCanvas = GameObject.Find("ShopCanvas").transform;
        levelsViewCanvas = GameObject.Find("LevelsCanvas").transform;
        audioManager = GameObject.Find("AudioManager");
        shopViewCanvas.gameObject.SetActive(false);
        levelsViewCanvas.gameObject.SetActive(false);
        shopCamera.gameObject.SetActive(false);
        levelsCamera.gameObject.SetActive(false);
    }
}
