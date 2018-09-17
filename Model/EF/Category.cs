namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }
        [StringLength(250, ErrorMessage = "Chỉ cho phép nhập 250 ký tự tối đa")]
        [DisplayName("Tên danh mục")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Chỉ cho phép nhập 250 ký tự tối đa")]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250, ErrorMessage = "Chỉ cho phép nhập 250 ký tự tối đa")]
        [DisplayName("Tên danh mục SEO")]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50, ErrorMessage = "Chỉ cho phép nhập 50 ký tự tối đa")]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50, ErrorMessage = "Chỉ cho phép nhập 50 ký tự tối đa")]
        public string ModifiedBy { get; set; }

        [StringLength(250, ErrorMessage = "Chỉ cho phép nhập 250 ký tự tối đa")]
        public string MetaKeywords { get; set; }
        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }
    }
}
