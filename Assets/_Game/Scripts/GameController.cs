using ABCToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField]private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject dummyPrefab;
    [SerializeField] private Transform PlayerCard;
    [SerializeField] private Transform EnemyCard;
    [SerializeField] private Transform DummyCard;


    private void Start()
    {

        if (!IsPlayerExists())
        {
            Debug.Log("Player does not exist");
            InitPlayer();
        }
        Invoke("InitEnemy", 1);
        //InitEnemy();
    }
    public bool IsPlayerExists()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void InitPlayer()
    {
        GameObject playerObj = Instantiate(playerPrefab, PlayerCard.transform.position, Quaternion.identity);
        playerCamera.GetComponent<ABC_CameraBase>().followTarget = playerObj;

    }
    public void InitEnemy()
    {
        Instantiate(enemyPrefab, EnemyCard.transform.position, Quaternion.identity);
    }
    public void SpawnDummy()
    {
        Instantiate(dummyPrefab, DummyCard.transform.position, Quaternion.identity);
    }

    public void RespawnPlayer()
    {
        if (!IsPlayerExists())
        {
            InitPlayer();
        }
        else
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            Destroy(obj);
            InitPlayer();
        }
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            InitEnemy();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnDummy();
        }
    }

#endif
}