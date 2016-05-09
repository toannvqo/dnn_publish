
using DotNetNuke.ComponentModel.DataAnnotations;
using System.Web.Caching;

namespace Christoc.Modules.DNNModule1
{
    [TableName("Product")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]
    //configure caching using PetaPoco
  
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
    }
}