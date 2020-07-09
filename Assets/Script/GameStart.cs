using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{public void OnClickStartButton() {
SceneManager.LoadScene("Scenes/WaterStage");
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

