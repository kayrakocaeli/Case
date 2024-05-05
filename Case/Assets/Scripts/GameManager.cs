using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public float startTime = 100f, time = 0f, fireRate=1f, normalFireRate;
    public int playerHP = 100, gold = 0, damage = 5, shootLevel = 0, diagonalShootLevel = 0,timer,attackSpeedLevel=0,DamageLevel=0;
    public double ISFee = 20f, ASFee = 10f,DFee=10f;
    public bool once=true;
    
    private static GameManager instance;
    public static GameManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        time = startTime;
        ISFee = (int)ISFee;
        ASFee = (int)ASFee;
        DFee = (int)DFee;
    }
    
    void Update()
    {
        Timer();
        SceneLoad();
    }
    public void Timer()
    {
        time -= 1 * Time.deltaTime;
        EventManager.StartToSetData();
        timer = (int)time;
    }
    public void SceneLoad()
    {
        if ((time <= 0 && once))
        {
            once = false;
            Time.timeScale = 0f;
            Win();
        }
        if ((playerHP <= 0 && once))
        {
            once = false;
            Time.timeScale = 0f;
            Lose();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            gold = 1000;
            EventManager.StartToSetData();
        }
    }
    
    public void Retry()
    {
        playerHP = 100;gold = 0; damage = 5; shootLevel = 0; diagonalShootLevel = 0;attackSpeedLevel = 0; DamageLevel = 0; ISFee = 20f; ASFee = 10f; DFee = 10f;
        EventManager.StartToSetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Win()
    {
        SceneManager.LoadScene("Win", LoadSceneMode.Additive);
    }
        
    public void Lose()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }
    public void NormalFireRate()
    {
        Invoke("DoFireRate", 5f);

    }
    void DoFireRate()
    {
        fireRate = normalFireRate;
    }

}
