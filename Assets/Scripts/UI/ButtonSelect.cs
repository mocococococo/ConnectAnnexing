

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/ButtonManager/Button").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
}
