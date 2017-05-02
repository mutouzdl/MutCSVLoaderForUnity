using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// CSV文件数据结构，基类
/// </summary>
public class BaseCsvData : ICloneable{
    public int ID { get; set; }

    /// <summary>
    /// 克隆对象，浅复制
    /// </summary>
    /// <returns></returns>
	public object Clone()
    {
        return MemberwiseClone();
    }
}
