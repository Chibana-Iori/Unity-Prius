using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Coin : MonoBehaviour {
 
    [SerializeField]
    float speed = -10.0f;
 
    Rigidbody2D rigidBody2D;
 
    bool inCamera = false;
 
    //初期化
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
 
    //物理演算
    void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y); ;
    }
 
    //カメラ内外の判定処理
    void OnBecameVisible()
    {
        inCamera = true;
    }
 
    void OnBecameInvisible()
    {
        if (inCamera)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}