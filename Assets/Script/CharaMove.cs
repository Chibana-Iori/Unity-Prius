using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool Move;
    

    //レーンの移動の数値をそれぞれの変数で宣言します。
    const int MinLane = -2;
    const int MaxLane = 2;
    string Direction;
    const float LaneWidth = 1.0f;

    //CharacterController型を変数controllerで宣言します。
    CharacterController controller;
    //Animator型を変数animatorで宣言します。
    Animator animator;

    //それぞれの座標を０で宣言します。
    Vector3 moveDirection = Vector3.zero;
    //int型を変数targetLaneで宣言します。
    int targetLane;

    //それぞれのパラメーターの設定をInspectorで変える様にします。
    public float gravity;
    float first_gravity = 10;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;
    
    void Start()
    {
        //GetComponentでCharacterControllerwp取得して変数controllseで参照します。
        controller = GetComponent<CharacterController>();
        //GetComponentでAnimatorを取得して変数animatorで参照します。
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (controller.isGrounded) gravity = 10;
        //それぞれの矢印が押されたらそれぞれの関数を実行します。
        //if (Input.GetKeyDown("left")) MoveToLeft();
        //if (Input.GetKeyDown("right")) MoveToRight();
        //if (Input.GetKeyDown("space")) Jump();
        //if (Input.GetKeyDown("down")) Sliding();
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            touchStartPos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,
            Input.mousePosition.z);
            }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
        touchEndPos = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y,
        Input.mousePosition.z);
        GetDirection();
        }
        
             
        float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;

        animator.SetBool("run", moveDirection.z > 0.0f);
        
    }
    void FixedUpdate(){
        if (Move){
            switch (Direction){
            //右移動
            case "right":
            MoveToRight();
            Move=false;
            break;
            //左移動
            case "left":
            MoveToLeft();
            Move=false;
            break;
            //ジャンプ
            case "up":
            Jump();
            Move=false;
            break;
            //スライディング
            case "down":
            Sliding();
            Move=false;
            break;
            case "touch":
            break;
            Move=false;
        }}
    }
    
    //新しく作った関数のそれぞれの処理。
    public void MoveToLeft()
    {
        // if (controller.isGrounded && targetLane > MinLane) targetLane--;
        if (targetLane > MinLane) targetLane--;
    }

    public void MoveToRight()
    {
        // if (controller.isGrounded && targetLane < MaxLane) targetLane++;
        if (targetLane < MaxLane) targetLane++;
    }

    public void Jump()
    {
        // 下のif文でジャンプの回数制限。地面についているときだけジャンプ可能
        // if (controller.isGrounded)
        // {

            moveDirection.y = speedJump;

            animator.SetTrigger("jump");
        // }
    }

    public void Sliding()
    {
        if (controller.isGrounded)
        {
            // moveDirection.y = speedJump;
            Debug.Log("下矢印");

            animator.SetTrigger("sliding");
        }else{
            gravity = 50;
        }
    
    }

    void GetDirection(){
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
            if (30 < directionX){
                //右向きにフリック
                Direction = "right";
                }else if (-30 > directionX){
                    //左向きにフリック
                    Direction = "left";
                    }
                    }
                    else if (Mathf.Abs(directionX)<Mathf.Abs(directionY)){
                        if (30 < directionY){
                            //上向きにフリック
                            Direction = "up";
                            }else if (-30 > directionY){
                                //下向きのフリック
                                Direction = "down";
                                }
                                }else{
                                    //タッチを検出
                                    Direction = "touch";
                                    }
                                    Move=true;
        }
    
    


}