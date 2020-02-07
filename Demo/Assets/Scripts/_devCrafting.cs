﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _devCrafting : MonoBehaviour
{
    [SerializeField] private displayIngredient[] _ingredients = new displayIngredient[3];
    private Vector3 _potionScore = Vector3.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CraftPotion();
        }
    }

    private void CraftPotion()
    {
        string output = "";
        _potionScore = Vector3.zero;

        foreach (var ingredients in _ingredients)
        {
            output += ingredients.Ingredient.Name + ", ";
            _potionScore += ingredients.Ingredient.Values;

            //can decrease Quantity, but is not checking quantity before hand. 
            //TODO Check Quantity during drag+drop onto crafting zone.
            ingredients.Ingredient.DecreaseQuantity(1);
        }

        Debug.Log("New Potion using " + output + ". Score is " + _potionScore);
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("Assets/Potions.csv");
        bool endOfFile = false;
        bool foundMatch = false;

        while (!endOfFile && !foundMatch)
        {
            Debug.Log("new line");
            string data_String = strReader.ReadLine();

            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            Debug.Log("data_String " + data_String);

            var data_values = data_String.Split(',');

            int[] parsedIntValues = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int parsedInt;
                bool attempt = int.TryParse(data_values[i], out parsedInt);

                if (attempt)
                    parsedIntValues[i] = parsedInt;
                else
                    Debug.Log("Found a Bad Potion Value");
                
            }

            Vector3 compareScore = new Vector3(parsedIntValues[0], parsedIntValues[1], parsedIntValues[2]);
            Debug.Log("compareScore " + compareScore);

            if (compareScore != _potionScore)   //instead of nesting the rest of the code in an if{} we can use a !if{}
            {
                continue;
            }

            Debug.Log("Match!\n" + data_values[3]);
            foundMatch = true;
        }
    }
}
