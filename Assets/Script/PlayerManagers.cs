using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagers : MonoBehaviour
{
    #region Singleton

    public static PlayerManagers instance;
    
    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
