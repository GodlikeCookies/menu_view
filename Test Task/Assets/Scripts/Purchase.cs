using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour
{
    public void OnPurchase(Product product)
    {
        switch (product.definition.id)
        {
            case "com.godlikecookies.testtask.500tickets":
                Add500Tickets();
                break;
            case "com.godlikecookies.testtask.1200tickets":
                Add1200Tickets();
                break;
        }
    }
    private void Add500Tickets()
    {
        Tickets.count += 500;
        Debug.Log("500 tickets purchased");
        Shop.UpdateItems();
    }
    private void Add1200Tickets()
    {
        Tickets.count += 1200;
        Debug.Log("1200 tickets purchased");
        Shop.UpdateItems();
    }
}
