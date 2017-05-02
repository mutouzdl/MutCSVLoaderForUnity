using System.Collections.Generic;

/// <summary>
/// CSV读取工具
/// 作者：笨木头 www.benmutou.com
/// 使用本代码时，请保留作者信息
/// </summary>
public class CsvLoader {

	/// <summary>
    /// 读取CSV文件
    /// 结果保存到字典集合，以ID作为Key值，对应每一行的数据，每一行的数据也用字典集合保存。
    /// </summary>
    /// <param name="filePath">CSV文件路径</param>
    /// <returns></returns>
    public static Dictionary<string, Dictionary<string, string>> LoadCsvFile(string filePath)
    {
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

        string[] fileData = FileLoader.LoadFileLines(filePath);

        if(fileData.Length < 3)
        {
            return result;
        }

        /* CSV文件的第一行为Key字段，第二行为说明（不需要读取），第三行开始是数据。第一个字段一定是ID。 */
        string[] keys = fileData[0].Split(',');
        for(int i = 2; i < fileData.Length; i++)
        {
            string[] line = fileData[i].Split(',');

            /* 以ID为key值，创建一个新的集合，用于保存当前行的数据 */
            string ID = line[0];
            result[ID] = new Dictionary<string, string>();
            for (int j = 0; j < line.Length; j++)
            {
                /* 每一行的数据存储规则：Key字段-Value值 */
                result[ID][keys[j]] = line[j];
            }
        }

        return result;
    }
}
