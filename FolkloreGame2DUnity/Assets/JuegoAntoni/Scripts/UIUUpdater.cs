using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUUpdater : MonoBehaviour
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
        pointsText.text = "Points: " + GameManager.Instance.currentPoints.ToString();
    }

   
}