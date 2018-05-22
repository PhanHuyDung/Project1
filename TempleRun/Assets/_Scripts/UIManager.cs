using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoSingleton<UIManager>
{
    [Header("Panel")]
    public GameObject panelStart;
    public GameObject panelPause;
    public GameObject panelGameOver;

    public Text txtScore;
    public Text txtDiamond;

    float score;
    float diamond;
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        DOTween.To(() => score, x => score = x, GameSetting.SCORE, 0.75f);
        DOTween.To(() => diamond, x => diamond = x, GameSetting.DIAMOND, 0.75f);
        txtScore.text = ((int)score).ToString();
        txtDiamond.text = ((int)diamond).ToString();
    }
}
