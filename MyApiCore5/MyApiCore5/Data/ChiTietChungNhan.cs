using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class ChiTietChungNhan
    {
        [Key]
        [MaxLength(100)]
        public string IDChiTietChungNhan { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string SoQuyetDinhOnline { get; set; }
        [MaxLength(100)]
        public string SoQuyetDinhOffline { get; set; }
        public DateTime NgayCapOnline { get; set; }
        public DateTime NgayCapOffline { get; set; }
        public int MSSV { get; set; }
        [MaxLength(100)]
        public string IDTrangThaiDuyet{get; set;}
        [MaxLength(100)]
        public string IDChungNhan { get; set;}
        [MaxLength(100)]
        public string IDAdmin1 { get; set; }
        [MaxLength(100)]
        public string IDAdmin2 { get; set; }
        [MaxLength(100)]
        public string IDAmin3 { get; set; }

    }
}
