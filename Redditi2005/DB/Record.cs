using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redditi2005.DB
{
    [Table("Records")]
    internal class Record
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; } = 0;

        [Column("Name")]
        public string Name { get; set; } = "";

        [Column("Birthday")]
        public string Birthday { get; set; } = "";

        [Column("RedditCategory")]
        public string RedditCategory { get; set; } = "";

        [Column("CompanyCategory")]
        public string CompanyCategory { get; set; } = "";

        [Column("Gross")]
        public int Gross { get; set; } = 0;

        [Column("NetTax")]
        public int NetTax { get; set; } = 0;

        [Column("CompanyReddit")]
        public int CompanyReddit { get; set; } = 0;

        [Column("Turnover")]
        public int Turnover { get; set; } = 0;

        [Column("ModelType")]
        public string ModelType { get; set; } = "";

        [Column("CityCode")]
        public string CityCode { get; set; } = "";
    }
}
