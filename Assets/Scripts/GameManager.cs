using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int _itemsStacked;
    bool _isGameOver = false;

    [SerializeField] GameObject _penaltyZone;

    static GameManager _instance;

    public static GameManager Instance
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
            Debug.LogError("GameManager duplicated", this);
        }
    }


    public void LossScreen()
    {
        Debug.Log("Lose");
        _penaltyZone.SetActive(false);

        SpawnManager.Instance.StopSpawning();
        UIManager.Instance.DisplayLossText();
        _isGameOver=true;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("StackerScene");
            }
        }
    }
}
