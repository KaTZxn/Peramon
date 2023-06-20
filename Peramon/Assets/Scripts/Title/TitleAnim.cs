using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class TitleAnim : MonoBehaviour
{
    [SerializeField]public GameObject[] arrow;
    public float animTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        ArrowAnim(animTime);
    }

    /// <summary>
    /// タイトル画面の矢印のアニメーション
    /// </summary>
    /// <param name="time">ループ時間</param>
    private void ArrowAnim(float time)
    {
        arrow[0].transform.DOLocalMove(new Vector3(0, -620, 0), time).SetLoops(-1, LoopType.Yoyo);
        arrow[1].transform.DOLocalMove(new Vector3(0, -240, 0), time).SetLoops(-1, LoopType.Yoyo);
        arrow[2].transform.DOLocalMove(new Vector3(-325, -430, 0), time).SetLoops(-1, LoopType.Yoyo);
        arrow[3].transform.DOLocalMove(new Vector3(325, -430, 0), time).SetLoops(-1, LoopType.Yoyo);
    }
}
