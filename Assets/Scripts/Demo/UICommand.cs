using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICommand : MonoBehaviour {
    public InputField inputFieldFilePath = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CachedCSV()
    {
        CsvDataCached.CachedCsvFile<EntityCsvData>(inputFieldFilePath.text);
        Debug.Log("缓存完毕！");
    }

    public void LoadCSV()
    {
        Dictionary<int, EntityCsvData> dataDic = CsvDataCached.GetCsvFileDatas<EntityCsvData>();

        Debug.Log("开始读取CSV文件对象");
        foreach (EntityCsvData csvData in dataDic.Values)
        {
            Debug.Log(csvData.ID + "：" + csvData.Name);
        }
        Debug.Log("读取CSV文件对象结束");
    }
}
