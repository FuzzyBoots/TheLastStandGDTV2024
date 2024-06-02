using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _tableModel;

    static SpawnManager _instance;

    public static SpawnManager Instance
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
            Debug.LogError("SpawnManager duplicated", this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(SpawnTables());
        SpawnNext();
    }

    public void SpawnNext()
    {
        Instantiate(_tableModel, new Vector3(0f, 10f, Random.Range(-25, 25) / 2f), Quaternion.identity);
    }
}
