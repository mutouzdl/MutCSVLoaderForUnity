# MutCSVLoaderForUnity
用于Unity上的CSV文件读取工具，兼具缓存、提取功能。

## 代码说明
核心的代码就四个，如果大家不想下载Demo工程的话，直接下载下面四个代码，放到你的Unity项目中即可:

1.FileLoader （在Assets/Scripts/CSVLoader/目录）
用于读取文件的工具栏，支持PC和Android平台，不支持iOS（木头本人不喜欢玩iOS，所以没去研究）

2.ReflectUtil （在Assets/Scripts/CSVLoader/目录）
反射辅助工具 （在Assets/Scripts/CSVLoader/目录）

3.CsvLoader （在Assets/Scripts/CSVLoader/目录）
核心类，用于读取CSV文件

4.CsvDataCached （在Assets/Scripts/Demo/目录）
核心类，用于缓存和提取CSV文件对象

## 使用说明
1.将以上四个文件放到你的Unity项目中

2.在 Assets/StreamingAssets/ 目录（如果没有则创建该文件夹）创建一个CSV文件，文件第一行为每列的属性名（对应代码里的属性），第二行为每列的属性说明。如:[Entity.csv](https://github.com/mutouzdl/MutCSVLoaderForUnity/blob/master/Assets/StreamingAssets/CSV/Entity.csv)

3.创建一个类，类结构和CSV文件完全对应（如EntityCsvData.cs），即类的属性名为CSV文件每一列的属性名

4.调用CsvDataCached.CachedCsvFile函数缓存文件：

`CsvDataCached.CachedCsvFile<EntityCsvData>("CSV/EntityCsv.csv");`

5.调用CsvDataCached.GetCsvFileDatas函数读取CSV文件对象：

        Dictionary<int, EntityCsvData> dataDic = CsvDataCached.GetCsvFileDatas<EntityCsvData>();

        foreach (EntityCsvData csvData in dataDic.Values)
        {
            Debug.Log(csvData.ID + "：" + csvData.Name);
        }

## 其他
木头是第一次在GitHub共享这些工具类，如果格式不对，或者代码无法运行，请告诉我一声，谢谢，我的邮箱：musicvs@163.com
