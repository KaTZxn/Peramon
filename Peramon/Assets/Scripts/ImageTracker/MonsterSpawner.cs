using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private ARObjectManager _arObjManager;
    public GameObject _arObj { get; set; }


    public void SpawningObject(int imageNum, Vector3 pos, Quaternion rot)
    {
        //int[] _monsterArray =  RandomMonsterNumArray(imageNum);
        for(int i = 0; i < 4; i++)
        {
            int _monsterID = 0;
            if(imageNum == 0) _monsterID = i;
            else if(imageNum == 1)_monsterID = i + 4;
            GameObject monster = Instantiate(_arObjManager.GetArObjByNum(_monsterID), MonsterPos(i,pos), rot);
            BaseMonster _baseMonster = monster.transform.GetChild(0).gameObject.GetComponent<BaseMonster>();
            _baseMonster.isSpecial = RandomMonsterSpecial(30);
            _baseMonster.isSpecial = true ?
                                            _baseMonster.haveTreasure = RandomMonsterSpecial(80) :
                                            _baseMonster.haveTreasure = RandomMonsterSpecial(50);
        }
        Debug.Log("Spawn");
    }

    private Vector3 MonsterPos(int _monsterNum, Vector3 _oPos)
    {
        Vector3 _pos = _oPos;
        switch(_monsterNum)
        {
            case 0:
                _pos = _oPos + new Vector3(0.1f,0f,0.1f);
                break;
            case 1:
                _pos = _oPos + new Vector3(-0.1f,0f,0.1f);
                break;
            case 2:
                _pos = _oPos + new Vector3(-0.1f,0f,-0.1f);
                break;
            case 3:
                _pos = _oPos + new Vector3(0.1f,0f,-0.1f);
                break;
            default:
                break;
        }
        return _pos;
    }


    private int RandomMonsterNum(int _num)
    {
        int _id = 0;
        switch (_num)
        {
            case 0:
                _id = Random.Range(0, 4);
                break;
            case 1:
                _id = Random.Range(5, 8);
                break;
            default:
                break;
        }
        Debug.Log(_id);
        return _id;
    }

    private bool RandomMonsterSpecial(int _prob)
    {
        return Random.Range(0, 100) < _prob;
    }
}