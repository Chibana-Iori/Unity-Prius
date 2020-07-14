using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParticle : MonoBehaviour
{

    private ParticleSystem particle;
    bool HitPlayFlag = false; //衝突有無（衝突イベント開始true）


    // Start is called before the first frame update
    void Start()
    {
        //パーティクル
        particle = this.GetComponent<ParticleSystem>();
        particle.Stop();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tree OnTriggerEnter");
            //パーティクルを表示する
            particle.Play();
            // 衝突イベント開始 
            HitPlayFlag = true;
        }
    }

    void LateUpdate()
    {
        //このゲームオブジェクトのパーティクルが生存しているかどうか.
        if (HitPlayFlag && !particle.IsAlive())
        {
            // 衝突イベント終了 
            HitPlayFlag = false;
            Destroy(gameObject);

        }
    }


}
