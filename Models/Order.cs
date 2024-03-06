using System.ComponentModel.DataAnnotations;

namespace House_Data.Models
{
    /// <summary>
    /// 成交資料
    /// </summary>
    public class Order
    {
        public int id { get; set; }

        [Display(Name = "成交編號")]
        public string OrderNo { get; set; }

        [Display(Name = "分店編號")]
        public int branchId { get; set; }

        [Display(Name = "業務員編號")]
        public int salesId { get; set; }

        [Display(Name = "物件編號")]
        public int HouseId { get; set; }

        [Display(Name = "成交價")]
        public int Amount { get; set; }


        [Display(Name = "成交日期")]
        public DateTime SaleDate { get; set; }

        public Sales Sales { get; set; }
        public House House { get; set; }

    }
}
