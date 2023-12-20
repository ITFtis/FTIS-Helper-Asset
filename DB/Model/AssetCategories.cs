namespace FtisHelperAsset.DB.Model
{
    using Dou.Misc.Attr;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssetCategories
    {
        [Key]
        [ColumnDef(Display = "類別編號", Sortable = true)]
        [StringLength(5)]
        public string CateID { get; set; }

        [ColumnDef(Display = "類別名稱", Sortable = true)]
        [StringLength(50)]
        public string Name { get; set; }

        [ColumnDef(Display = "類別描述", Sortable = true)]
        [StringLength(255)]
        public string Description { get; set; }

        public List<AssetSubCategories> SubCate { set; get; }
    }
}
