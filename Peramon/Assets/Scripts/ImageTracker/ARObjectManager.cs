using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    [SerializeField]private GameObject[] _arObjs;

    public GameObject GetArObjByNum(int _pageNum)
    {
        return _arObjs[_pageNum];
    }
}
