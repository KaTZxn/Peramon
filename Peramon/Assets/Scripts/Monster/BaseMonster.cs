using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    public bool isSpecial;
    public bool haveTreasure;
    public int touchCount = 0;
    private bool isKilled;
    private Vector3 spawnPosition;
    [SerializeField]public int monsterID;
    // Start is called before the first frame update
    void Start()
    {
        touchCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(touchCount>=3 && isSpecial)
            isSpecial = false;
    }
}
