using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageMar : MonoBehaviour {

    private static LanguageMar instance;
    /// <summary>
    /// 单例
    /// </summary>
    public static LanguageMar Instance {
        get { return instance; }
    }

    //选择语言
    [SerializeField]
    private SystemLanguage language;

    //存储加载出来的Key，Value
    Dictionary<string, string> dict = new Dictionary<string, string>();


    /// <summary>
    /// 加载预翻译语言
    /// </summary>
    private void LoadLanguage()
    {
     
        TextAsset ta = Resources.Load<TextAsset>(language.ToString());
        
        if (ta == null) { Debug.LogWarning("没有此语言的预编译"); return; }

        //分割行，，
         string[] lines = ta.text.Split('\n');

        //读取key : value，并存到上面字典中
        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrEmpty(lines[i]))
            {
                continue;
            }
            else
            {

                string[] kv = lines[i].Split(':');                

                //存到字典中
                dict.Add(kv[0], kv[1]);

                Debug.Log("Key:" + kv[0] + "Value:" + kv[1]);
            }
        }
    }
    
    /// <summary>
    /// 获取值
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>返回所对应的值，若不存在返回空</returns>
    public string GetTest(string key)
    {
        if (dict.ContainsKey(key))
        {
            return dict[key];
        }
        else {
            
            return null;
        }
    }

    void Awake () {
        instance = this;

        LoadLanguage();

    }
	
}
