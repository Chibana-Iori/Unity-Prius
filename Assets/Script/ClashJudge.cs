using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClashJudge : MonoBehaviour
{
    public GameObject particle;//Particleを宣言
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Clash3");
     
        if(collision.gameObject.CompareTag("Cube")){
     Debug.Log("Clash");
            SceneManager.LoadScene("GameOver");
          }
          if(collision.gameObject.CompareTag("Cube3")){
     Debug.Log("Clash");
            SceneManager.LoadScene("GameOver");
          }
          if(collision.gameObject.CompareTag("Enemy")){
              Instantiate(particle, transform.position, transform.rotation);
              Destroy(collision.gameObject);
              Debug.Log("Clash");
              SceneManager.LoadScene("GameOver");
              }
            if(collision.gameObject.CompareTag("Bomb")){
                Instantiate(particle, transform.position, transform.rotation);
                Destroy(collision.gameObject);
                Debug.Log("Clash");
                SceneManager.LoadScene("GameOver");
                }
    }

// Start is called before the first frame update
    void Start()
    {
    
    }

// Update is called once per frame
    void Update()
    {
    
    }
}