using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWord : MonoBehaviour {


	// Use this for initialization
	void Start () {
       //获取名字所对的键的值，并且赋值于文本用于显示 
       this.gameObject.GetComponent<Text>().text = LanguageMar.Instance.GetTest(this.gameObject.name);
       // Debug.Log(text);
    }
	
}
