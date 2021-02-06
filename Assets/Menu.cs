using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text title;
    Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay = gameObject.GetComponent<Button>();
        btnPlay.onClick.AddListener(onClickPlay);
    }

void onClickPlay(){
title.text = "aaaaaa";
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
