using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;
    //時間間隔の最小値
    public float minTime = 15f;
    //時間間隔の最大値
    public float maxTime = 30f;
    //X座標の最小値
    public float xMinPosition = -3f;
    //X座標の最大値
    public float xMaxPosition = 3f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    public Transform character;

    private GameObject enemy;

    public int enemycount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            enemy = Instantiate(enemyPrefab);
            enemycount += 1;
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
       
    
        }

        if (enemy.transform.position.z < character.position.z - 4)
        {
            DestroyEnemy();
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float z = character.position.z + 40;
        float y = 0.5f;
        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        GameObject oldenemy = enemy;
        Destroy(oldenemy);
        enemycount -= 1;
    }

   
}