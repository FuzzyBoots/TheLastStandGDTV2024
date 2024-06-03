using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _tableModel;
    [SerializeField] private Transform _furnitureContainer;

    static SpawnManager _instance;
    private float _highestY;
    private bool _spawning;

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

    private IEnumerator SpawnTables()
    {
        while(_spawning) {
            GameObject spawned = Instantiate(_tableModel, new Vector3(Random.Range(-12, 12) / 48f, _highestY + 2f, 0f), Quaternion.identity);
            // Debug.Log($"Spawned at {spawned.transform.position}");
            spawned.transform.parent = _furnitureContainer;
            UIManager.Instance.SetStacked(_furnitureContainer.transform.childCount);
            yield return new WaitForSeconds(3f);
        }
    }

    public void StartSpawning()
    {
        _spawning = true;
        StartCoroutine(SpawnTables());
    }

    public void StopSpawning()
    {
        _spawning = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    internal void SetHighestPoint(float highestY)
    {
        _highestY = highestY;
        Vector3 position = transform.position;
        position.y = highestY + 2f;

        transform.position = position;
    }
}
