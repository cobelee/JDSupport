using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class WeibaoLogViewModel
{
    /// <summary>
    /// 设备Id
    /// </summary>
    public Guid AppId { get; set; }
    /// <summary>
    /// 设备管理号
    /// </summary>
    public string ProductSN { get; set; }

    /// <summary>
    /// 固定资产号
    /// </summary>
    public string AssetSN { get; set; }

    /// <summary>
    /// 设备大类
    /// </summary>
    public string BigClass { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public string AppType { get; set; }

    /// <summary>
    /// 型号规格
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// 所属单位
    /// </summary>
    public string OwnerDepName { get; set; }

    /// <summary>
    /// 安装地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 维保内容
    /// </summary>
    public string WbContent { get; set; }

    /// <summary>
    /// 维保日期
    /// </summary>
    public DateTime WbDate { get; set; }

    /// <summary>
    /// 维保人
    /// </summary>
    public string WbRealName { get; set; }

}