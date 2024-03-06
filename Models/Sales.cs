using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace House_Data.Models
{
    /// <summary>
    /// 業務員資料
    /// </summary>
    public class Sales
    {
        public int id { get; set; }

        [Display(Name = "分店編號")]
        public int branchId { get; set; }

        [Display(Name = "業務員名稱")]
        public string? salesName { get; set; }

        public ICollection<Order> Order { get; }
        public ICollection<House> House { get; }

    }
}
