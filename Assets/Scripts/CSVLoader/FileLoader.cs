using UnityEngine;
using System.IO;
using System;


/// <summary>
/// 文件读取工具类
/// 作者：笨木头 www.benmutou.com
/// 使用本代码时，请保留作者信息
/// </summary>
public class FileLoader  {
    /// <summary>
    /// 读取文件，结果保存到一个string数组，数组的每一行就是文件的每一行
    /// （只支持PC和Android，不支持iOS，因为木头不玩iOS）
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public static string[]  LoadFileLines(string filePath)
    {
        string url = Application.streamingAssetsPath + "/" + filePath;
#if UNITY_EDITOR
        return File.ReadAllLines(url);
#elif UNITY_ANDROID
        WWW www = new WWW(url);
        while (!www.isDone) { }
        return www.text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
#else
        return File.ReadAllLines(url);
#endif
    }

}
