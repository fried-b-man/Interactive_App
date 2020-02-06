﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenuUIController : MonoBehaviour
{
    private void OnEnable()
    {
        ShopMenuController.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        ShopMenuController.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(ShopState state)
    {
        switch (state)
        {
            case ShopState.Shop:
                Debug.Log("Load Shop deals of the day");
                break;
            case ShopState.Crafting:
                SceneManager.LoadScene("CraftingTable");
                break;
            case ShopState.Journal:
                SceneManager.LoadScene("Journal");
                break;
            default:
                Debug.Log("State Not Yet Implemented");
                break;
        }
    }
}