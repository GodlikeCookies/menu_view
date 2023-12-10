using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tickets : MonoBehaviour
{
    public static int count;

    private void Update()
    {
        GetComponent<Text>().text = count.ToString();
    }
}
