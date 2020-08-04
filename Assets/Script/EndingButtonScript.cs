using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButtonScripts : MonoBehaviour
{
    public void OnClickEndingButton()
    {
        SceneManager.LoadScene("GameStart");
    }
}
