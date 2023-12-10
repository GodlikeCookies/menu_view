using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    private static int rewardedDay = 0;
    private DateTime lastDayReward;
    List<GameObject> rewardButtons = new List<GameObject>();

    private Dictionary<int, int> rewards = new Dictionary<int, int>()
    {
        {1, 5},
        {2, 5},
        {3, 10},
        {4, 10},
        {5, 15},
        {6, 15},
        {7, 5},
    };

    private int firstDaySliderValue = 7;
    public void OpenPanel()
    {
        rewardButtons.Clear();
        //if (DateTime.Now.Day - lastDayReward.Day > 1) rewardedDay = 0;

        if (rewardedDay == 6)
        {
            GameObject lastDayPanel = GameObject.Instantiate(PlacebleObjectsData.LoadFromAssets().day7BonusPanel, ObjectsContainer.menuViewCanvas);
            rewardedDay++;
            Tickets.count += rewards[rewardedDay];
            lastDayPanel.GetComponent<Button>().onClick.AddListener(delegate { CloseLastDayPanel(lastDayPanel); });
        }
        else
        {
            GameObject bonusPanel = GameObject.Instantiate(PlacebleObjectsData.LoadFromAssets().weeklyBonusPanel, ObjectsContainer.menuViewCanvas);
            if (rewardedDay == 0) bonusPanel.transform.GetChild(2).GetChild(0).GetComponent<Slider>().value = 0;
            else bonusPanel.transform.GetChild(2).GetChild(0).GetComponent<Slider>().value = firstDaySliderValue + rewardedDay - 1;
            bonusPanel.transform.GetChild(2).GetChild(3).GetComponent<Text>().text = $"{rewardedDay}/7";
            for (int i = 0; i < bonusPanel.transform.GetChild(3).GetChild(0).childCount; i++) rewardButtons.Add(bonusPanel.transform.GetChild(3).GetChild(0).GetChild(i).gameObject);
            for (int i = 0; i < bonusPanel.transform.GetChild(3).GetChild(1).childCount; i++) rewardButtons.Add(bonusPanel.transform.GetChild(3).GetChild(1).GetChild(i).gameObject);
            if (rewardedDay == 7)
            {
                for (int i = 0; i < rewardedDay - 1; i++)
                {
                    rewardButtons[i].transform.GetChild(3).gameObject.SetActive(true);
                    rewardButtons[i].transform.GetChild(4).gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < rewardedDay; i++)
                {
                    rewardButtons[i].transform.GetChild(3).gameObject.SetActive(true);
                    rewardButtons[i].transform.GetChild(4).gameObject.SetActive(false);
                }
            }
            if (DateTime.Now.Day != lastDayReward.Day || lastDayReward == null)
            {
                if (rewardedDay == 7) return;
                rewardButtons[rewardedDay].transform.GetChild(4).gameObject.SetActive(false);
                rewardButtons[rewardedDay].GetComponent<Button>().onClick.AddListener(GetReward);
            }
        }
    }
    public void ClosePanel()
    {
        GameObject.Destroy(gameObject);
    }
    void CloseLastDayPanel(GameObject panel)
    {
        GameObject.Destroy(panel);
    }

    public void GetReward()
    {
        rewardButtons[rewardedDay].GetComponent<Button>().onClick.RemoveListener(GetReward);
        rewardButtons[rewardedDay].transform.GetChild(3).gameObject.SetActive(true);
        rewardedDay++;
        lastDayReward = DateTime.Now;
        Tickets.count += rewards[rewardedDay];
    }
    private void Update()
    {
        if (rewardedDay != 0 && transform.GetChild(2).GetChild(0).GetComponent<Slider>().value < firstDaySliderValue + rewardedDay - 1)
        {
            transform.GetChild(2).GetChild(0).GetComponent<Slider>().value += 0.05f;
            transform.GetChild(2).GetChild(3).GetComponent<Text>().text = $"{rewardedDay}/7";
        }
    }
}
