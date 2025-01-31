using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance != null) Debug.Log("Jugando");
            return instance;
        }
    }
    public int currentPoints;
    public int winPoints;
  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
