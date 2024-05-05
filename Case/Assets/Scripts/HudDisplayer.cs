using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HudDisplayer : MonoBehaviour
{
    public GameManager manager;
    public TMP_Text goldDisplay,timerDisplay,healthDisplay,attackSpeedDisplay,damageLevelDisplay,diagonalShootDisplay,numberOfShoots,IEG,DS,ASL,DL,TAS,DG,ASG,DSG,FG;
    private void Start()
    {
        EventManager.SetDatas += SetHud;
    }
    void SetHud()
    {
        GameManager.Instance.ISFee = (int)GameManager.Instance.ISFee;
        GameManager.Instance.ASFee = (int)GameManager.Instance.ASFee;
        GameManager.Instance.DFee = (int)GameManager.Instance.DFee;

        goldDisplay.text = GameManager.Instance.gold.ToString();
        timerDisplay.text = GameManager.Instance.timer.ToString();
        healthDisplay.text = GameManager.Instance.playerHP.ToString();
        attackSpeedDisplay.text = GameManager.Instance.attackSpeedLevel.ToString();
        damageLevelDisplay.text = GameManager.Instance.DamageLevel.ToString();
        diagonalShootDisplay.text = GameManager.Instance.diagonalShootLevel.ToString();
        numberOfShoots.text = GameManager.Instance.shootLevel.ToString();
        IEG.text = GameManager.Instance.ISFee.ToString();
        DS.text = "15";
        ASL.text = GameManager.Instance.ASFee.ToString();
        DL.text = GameManager.Instance.DFee.ToString();
        TAS.text = "15";


        if (GameManager.Instance.DamageLevel == 40)
        {

            damageLevelDisplay.text = "MAX";
            DG.enabled = false;
            DL.enabled = false;

        }

        if (GameManager.Instance.attackSpeedLevel == 40)
        {
            attackSpeedDisplay.text = "MAX";
            ASL.enabled = false;
            ASG.enabled = false;
        }

        if (GameManager.Instance.diagonalShootLevel == 1)
        {
            diagonalShootDisplay.text = "ON";
            DSG.enabled = false;
            DS.enabled = false;
        }
        if (GameManager.Instance.shootLevel == 4)
        {
            IEG.text = "MAX";
            FG.enabled = false;
        }
    }
}
