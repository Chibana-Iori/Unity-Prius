using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

public AudioClip sound1;
AudioSource audioSource;

 void Start () {
   //Componentを取得
   audioSource = GetComponent<AudioSource>();
 }

 void Update () {
   // 左
  if (Input.GetKey (KeyCode.Space)) {
   //音(sound1)を鳴らす
    audioSource.PlayOneShot(sound1);
   }
 }
}