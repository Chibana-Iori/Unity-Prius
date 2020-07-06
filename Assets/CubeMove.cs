using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    //float型を変数moveStateで宣言します。
    public float moveState;
    //float型を変数speedで宣言します。
    public float speed;
    //Vector3型を変数vectorで宣言します。
    Vector3 vector;

    void Start()
    {
        //初期位置を保存します。
        vector = transform.localPosition;
    }


    void Update()
    {
        //x軸に移動する移動範囲とスピードの計算をします。
        float x = moveState * Mathf.Sin(Time.time * speed);
        //割当られた数値を元にx軸のポジションを決定します。
        transform.localPosition = vector + new Vector3(x, 0, 0);
    }
}