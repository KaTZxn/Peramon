using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTouchCheck : TouchCheck
{


    // Update is called once per frame
    void Update()
    {
        
    }
    private void TouchDetect()
    {
        //タッチされたら
        if (Input.touchCount > 0)
        {

            //タッチを取得
            Touch touch = Input.touches[0];
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObject;
            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hitObject))
                {
                    // m_score++;
                    // score.text = m_score + "/5";

                    _tearing = hitObject.transform.gameObject.GetComponent<Tearing>();
                    //Destroy(hitObject.transform.gameObject);
                }
            }
            switch (touch.phase)
            {

                //タッチ開始時
                case TouchPhase.Began:

                    if (touch.phase == TouchPhase.Began)
                    {

                        //タッチのポジションを取得してstartPosに代入
                        startPos = touch.position;

                        if (Physics.Raycast(ray, out hitObject))
                        {
                            // m_score++;
                            // score.text = m_score + "/5";

                            _tearing = hitObject.transform.gameObject.GetComponent<Tearing>();
                            //Destroy(hitObject.transform.gameObject);
                        }
                    }

                    break;



                //タッチ終了時
                case TouchPhase.Ended:


                    //タッチ終了のポジションをendPosに代入
                    endPos = new Vector2(touch.position.x, touch.position.y);

                    //横方向判定
                    //X方向にスワイプした距離を算出
                    swipeDistX = (new Vector3(endPos.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistX > minSwipeDistX)
                    {

                        //x座標の差分のサインを計算
                        //xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                        directionX = Mathf.Sign(endPos.x - startPos.x);

                        if (directionX > 0)
                        {
                            _tearing.TearDirection(Direction.Left);
                        }
                        else if (directionX < 0)
                        {
                            _tearing.TearDirection(Direction.Right);
                        }
                    }

                    //縦方向判定
                    //Y方向にスワイプした距離を算出
                    swipeDistY = (new Vector3(0, endPos.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    //差分が最低スワイプ分を超えていた場合
                    if (swipeDistY > minSwipeDistY)
                    {

                        //y座標の差分のサインを計算
                        //yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                        directionY = Mathf.Sign(endPos.y - startPos.y);

                        if (directionY > 0)
                        {
                            _tearing.TearDirection(Direction.Up);
                        }
                        else if (directionY < 0)
                        {
                            _tearing.TearDirection(Direction.Down);
                        }
                    }
                    break;
            }
        }
        //タッチフェーズによって場合分け
    }
}
