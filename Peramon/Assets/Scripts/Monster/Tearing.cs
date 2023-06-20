using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Tearing : MonoBehaviour
{
    Material m_material;
    [SerializeField]GameObject treasure;
    [SerializeField, Range(-15, 15)] public float disappearPointStartLeft, disappearPointEndLeft;
    [SerializeField, Range(-15, 15)] public float disappearPointStartRight, disappearPointEndRight;
    [SerializeField, Range(-15, 15)] public float disappearPointStartUp, disappearPointEndUp;
    [SerializeField, Range(-15, 15)] public float disappearPointStartDown, disappearPointEndDown;
    bool isTeared = false;
    // Start is called before the first frame update
    void Start()
    {
        m_material = GetComponent<MeshRenderer>().material;
    }

    public void TearDirection(TouchCheck.Direction direction)
    {
        //剥がす処理
        if (!isTeared)
        {
            switch (direction)
            {
                case TouchCheck.Direction.Up:
                    TearUp();
                    break;
                case TouchCheck.Direction.Down:
                    TearDown();
                    break;
                case TouchCheck.Direction.Left:
                    TearLeft();
                    break;
                case TouchCheck.Direction.Right:
                    TearRight();
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 左方向に剥がす
    /// </summary>
    private void TearLeft()
    {
        m_material.SetFloat("_AngleX", 0);
        m_material.DOFloat(180, "_AngleX", 1f);
        Invoke("DisappearLeft", 0.5f);
        TearMonster();
    }
    /// <summary>
    /// 右方向に剥がす
    /// </summary>
    private void TearRight()
    {
        m_material.SetFloat("_AngleX2", 0);
        m_material.DOFloat(180, "_AngleX2", 1f);
        Invoke("DisappearRight", 0.5f);
        TearMonster();
    }
    /// <summary>
    /// 上方向に剥がす
    /// </summary>
    private void TearUp()
    {
        m_material.SetFloat("_AngleY", 0);
        m_material.DOFloat(180, "_AngleY", 1f);
        Invoke("DisappearUp", 0.5f);
        TearMonster();
    }

    /// <summary>
    /// 下方向に剥がす
    /// </summary>
    private void TearDown()
    {
        m_material.SetFloat("_AngleY2", 0);
        m_material.DOFloat(180, "_AngleY2", 1f);
        Invoke("DisappearDown", 0.5f);
        TearMonster();
    }
    /// <summary>
    /// 剥がしたモンスターのデータを取得
    /// </summary>
    private void TearMonster()
    {
        isTeared = true;
        
        //モンスターを破壊する
        if(GetComponent<BaseMonster>().haveTreasure) SpawnTreasure();
        //Invoke("SpawnTreasure", 1f);
        AddTearMonster(GetComponent<BaseMonster>().haveTreasure);
        Destroy(this.gameObject, 2f);
    }

    /// <summary>
    /// 宝を生成
    /// </summary>
    private void SpawnTreasure()
    {
        Vector3 pos = this.gameObject.transform.parent.position;
        //宝生成の処理
        GameObject _treasure = Instantiate(treasure, pos, Quaternion.identity);
        Destroy(_treasure, 1.5f);
    }

    /// <summary>
    /// 剥がしたモンスターをセーフする
    /// </summary>
    private void AddTearMonster(bool haveTreasure = false)
    {
        //PlayerDataを検索
        PlayerData playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        //モンスターIDを取得
        int monsterID = GetComponent<BaseMonster>().monsterID;
        //PlayerDataへ剥がしたモンスターのIDを送る
        playerData.AddGotMonster(monsterID, haveTreasure);
    }

    /// <summary>
    /// モンスターが消える方向
    /// 左方向へ消える
    /// </summary>
    private void DisappearLeft()
    {
        m_material.SetFloat("_DisappearOffsetX", disappearPointStartLeft);
        m_material.DOFloat(disappearPointEndLeft, "_DisappearOffsetX", 0.8f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 右方向へ消える
    /// </summary>
    private void DisappearRight()
    {
        m_material.SetFloat("_DisappearOffsetX2", disappearPointStartRight);
        m_material.DOFloat(disappearPointEndRight, "_DisappearOffsetX2", 0.8f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 上方向へ消える
    /// </summary>
    private void DisappearUp()
    {
        m_material.SetFloat("_DisappearOffsetY", disappearPointStartUp);
        m_material.DOFloat(disappearPointEndUp, "_DisappearOffsetY", 0.8f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 下方向へ消える
    /// </summary>
    private void DisappearDown()
    {
        m_material.SetFloat("_DisappearOffsetY2", disappearPointStartDown);
        m_material.DOFloat(disappearPointEndDown, "_DisappearOffsetY2", 0.8f);
    }


}
