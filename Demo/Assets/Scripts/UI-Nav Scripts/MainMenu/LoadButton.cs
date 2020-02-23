﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadButton : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private MainMenuUIController _mainMenuController = null;
    [SerializeField] private StateController _stateController = null;

    private Button _button = null;
    public int _loadSetting { get; private set; } = 0;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnClick()
    {
        _stateController.ChangeLoadFile(_mainMenuController.LoadFileSetting);
        _stateController.ChangeState((int)MenuState.Menu);
    }
}