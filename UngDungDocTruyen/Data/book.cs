using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UngDungDocTruyen.Data
{

    [Table("book")]
    public class book
    {
        public string MaBook { get; set; }

        public string NameBoook { get; set; }

        public string TacGia { get; set; }

        public int NamXuatBan { get; set; }

        public string Mota { get; set; } 
    }
}
