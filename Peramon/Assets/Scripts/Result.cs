using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] public Text treasureText;
    [SerializeField] public Vector3[] _imagePos;
    [SerializeField] public GameObject[] _monsterImage;
    [SerializeField] public Transform _transform;
    PlayerData _playerData;
    private bool resultEnd = false;

    List<int> gotMonster;
    // Start is called before the first frame update
    void Start()
    {
        resultEnd = false;
        gotMonster = new List<int>();
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        StartCoroutine("ResultImage", 0.5f);
    }

    void Update()
    {
        ToTitle();
    }

    /// <summary>
    /// 剥がしたモンスターの画像生成
    /// </summary>
    /// <returns></returns>
    IEnumerator ResultImage()
    {
        TreasureResultTextUpdate();
        gotMonster.AddRange(_playerData.gotMonster);
        for (int i = 0; i < gotMonster.Count; i++)
        {
            GameObject _monsterImg = Instantiate(_monsterImage[gotMonster[i]], _transform);
            _monsterImg.GetComponent<Transform>().localPosition = _imagePos[i];
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(10);
        resultEnd = true;
    }

    private void TreasureResultTextUpdate()
    {
        treasureText = GameObject.Find("Score").GetComponent<Text>();
        treasureText.text = "獲得した宝の数：" + _playerData.gotTreasure;
    }

    /// <summary>
    /// タイトルへ移動
    /// </summary>
    private void ToTitle()
    {
        if (!resultEnd)
            return;

        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(0);
            _playerData.ResetData();
        }
    }
}
