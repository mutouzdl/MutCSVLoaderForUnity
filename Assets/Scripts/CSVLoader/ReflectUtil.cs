using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

/// <summary>
/// 反射工具类
/// 作者：笨木头 www.benmutou.com
/// 使用本代码时，请保留作者信息
/// </summary>
public class ReflectUtil  {
    /// <summary>
    /// 给属性赋值
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="value">值</param>
    /// <param name="pi">反射的属性对象</param>
    /// <param name="obj">被赋值的对象</param>
    public static void PiSetValue<T>(string value, PropertyInfo pi, T obj)
    {
        /* ChangeType无法强制转换可空类型，所以需要这样特殊处理（参考：http://bbs.csdn.net/topics/320213735） */
        if (pi.PropertyType.FullName.IndexOf("Boolean") > 0)
        {
            /* 布尔类型要特殊处理  */
            pi.SetValue(obj, Convert.ChangeType(Convert.ToInt16(value), (Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType)), null);
        }
        else
        {
            pi.SetValue(obj, Convert.ChangeType(value, (Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType)), null);
        }
    }

}
