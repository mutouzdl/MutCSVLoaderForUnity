using System.Collections.Generic;
using System;
using System.Reflection;

/// <summary>
/// CSV配置文件数据缓存
/// 游戏运行时会自动加载所有的CSV文件，将各个CSV数据对象缓存到这个类里。
/// </summary>
public class CsvDataCached  {
    /// <summary>
    /// 存放所有CSV数据缓存
    /// </summary>
    private static Dictionary<Type, object> csvDatas = new Dictionary<Type, object>();

    static CsvDataCached()
    {
        /* 可以在这里缓存CSV配置数据 */
        //CachedCsvFile<LevelMonsterCreaterCsvData>("CSV/LevelMonsterCreater.csv");
    }

    /// <summary>
    /// 获取CSV数据对象
    /// </summary>
    /// <typeparam name="T_CsvData">数据对象类型（如MonsterCsvData）</typeparam>
    /// <param name="ID">配置ID</param>
    /// <returns>CSV文件某一行内容的数据对象</returns>
    public static T_CsvData GetCsvLineData<T_CsvData>(int ID)
    {
        Type type = typeof(T_CsvData);

        /* 取出存放该数据对象类型的字典 */
        Dictionary<int, T_CsvData> dic = GetCsvFileDatas<T_CsvData>();

        /* 从字典中取出某个ID的数据 */
        if (dic.ContainsKey(ID) == true)
        {
            return dic[ID];
        }
        return default(T_CsvData);
    }

    /// <summary>
    /// 获取某个CSV文件的所有数据，返回字典集合，Key为ID，Value为每一行的数据对象
    /// </summary>
    /// <typeparam name="T_CsvData">文件数据类型</typeparam>
    /// <returns></returns>
    public static Dictionary<int, T_CsvData> GetCsvFileDatas<T_CsvData>()
    {
        Type type = typeof(T_CsvData);

        if (csvDatas.ContainsKey(type) == true)
        {
            /* 取出存放该数据对象类型的字典 */
            object dicObj = csvDatas[type];

            return (Dictionary<int, T_CsvData>)dicObj;
        }

        return new Dictionary < int, T_CsvData >() ;
    }

    /// <summary>
    /// 缓存CSV文件
    /// </summary>
    /// <typeparam name="T_CsvData">CSV数据对象类型</typeparam>
    /// <param name="filePath">CSV文件路径，确保CSV文件存放在Assets/StreamingAssets目录（或子目录）</param>
    public static void CachedCsvFile<T_CsvData>(string filePath)
    {
        csvDatas[typeof(T_CsvData)] = LoadCsvData<T_CsvData>(filePath);
    }

    /// <summary>
    /// 读取CSV文件数据（利用反射）
    /// </summary>
    /// <typeparam name="CsvData">CSV数据对象的类型</typeparam>
    /// <param name="csvFilePath">CSV文件路径</param>
    /// <param name="csvDatas">用于缓存数据的字典</param>
    /// <returns>CSV文件所有行内容的数据对象</returns>
    private static Dictionary<int, T_CsvData> LoadCsvData<T_CsvData>(string csvFilePath)
    {
        Dictionary<int, T_CsvData> dic = new Dictionary<int, T_CsvData>();

        /* 从CSV文件读取数据 */
        Dictionary<string, Dictionary<string, string>> result = CsvLoader.LoadCsvFile(csvFilePath);

        /* 遍历每一行数据 */
        foreach (string ID in result.Keys)
        {
            /* CSV的一行数据 */
            Dictionary<string, string> datas = result[ID];

            /* 读取Csv数据对象的属性 */
            PropertyInfo[] props = typeof(T_CsvData).GetProperties();

            /* 使用反射，将CSV文件的数据赋值给CSV数据对象的相应字段，要求CSV文件的字段名和CSV数据对象的字段名完全相同 */
            T_CsvData obj = Activator.CreateInstance<T_CsvData>();
            foreach (PropertyInfo p in props)
            {
                ReflectUtil.PiSetValue<T_CsvData>(datas[p.Name], p, obj);
            }

            /* 按ID-数据的形式存储 */
            dic[Convert.ToInt32(ID)] = obj;
        }

        return dic;
    }
}

