using System.ComponentModel.DataAnnotations;

namespace Api_Data.Data
{
    public class DataCSV
    {
        [MaxLength(200)]
        public string journal_name { get; set; }
        [MaxLength(200)]
        public string issn { get; set;}
        [MaxLength(200)]
        public string eissn { get; set; }
        [MaxLength(200)]
        public string category1 { get; set; }
        [MaxLength(200)]
        public string category2 { get; set; }
        [MaxLength(200)]
        public string category3 { get; set; }
        [MaxLength(200)]
        public string category4 { get; set; }
        [MaxLength(200)]
        public string category5 { get; set; }
        [MaxLength(200)]
        public string category6 { get; set; }
        [MaxLength(200)]
        
        public string citations { get; set; }
        [MaxLength(200)]
        public string if_2022 { get; set; }
        [MaxLength(200)]
        public string jci { get; set; }
        [MaxLength(200)]
        public string percentageOAGold { get; set; }
        [Key]
        public int number { get; set; }
    }
}
