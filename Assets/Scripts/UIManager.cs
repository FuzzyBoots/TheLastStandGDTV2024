using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _stackedText;
    [SerializeField] private TMP_Text _gameOverText;

    static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("UIManager duplicated", this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStacked(int stacked)
    {
        _stackedText.text = $"Stacked: {stacked}";
    }

    internal void DisplayLossText()
    {
        _gameOverText.enabled = true;
    }
}
