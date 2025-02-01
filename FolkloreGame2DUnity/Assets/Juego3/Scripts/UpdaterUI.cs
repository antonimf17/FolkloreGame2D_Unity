using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdaterUI : MonoBehaviour
{
    [Header("GameStatusPanels")]
    [SerializeField] GameObject gameOverPanel;

    public TMP_Text pointsText;


    void Update()
    {
        PointsUpdater();
       
    }

    void PointsUpdater()
    {
        pointsText.text = "Wolves Killed: " + GameManager.Instance.WolfsKilled.ToString();
    }

   
}