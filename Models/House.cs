using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace House_Data.Models
{
    /// <summary>
    /// 房屋物件資料
    /// </summary>
    public class House
    {
        public int id { get; set; }

        [Display(Name = "物件名稱")]
        public string? name { get; set; }

        [Display(Name = "物件代碼")]
        public string? Serial { get; set; }

        [Display(Name = "地區")]
        public string? region { get; set; }

        [Display(Name = "售價")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Amount { get; set; }

        [Display(Name = "坪數")]
        public decimal? area { get; set; }

        [Display(Name = "格局類型")]
        public string? houseType { get; set; }

        [Display(Name = "屋齡")]
        public string? houseAge { get; set; }

        [Display(Name = "業務員")]
        public int? salesId { get; set; }


        [Display(Name = "新增日期")]
        [DataType(DataType.Date)]
        public DateTime cDate { get; set; }

        [Display(Name = "修改日期")]
        [DataType(DataType.Date)]
        public DateTime uDate { get; set; }

        public Order? Order { get; set; }
        public Sales? Sales { get; set; }

    }
}
