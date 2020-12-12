using Infrastructure.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualTable.ViewModel
{
    public class TableView
    {
        [Required(ErrorMessage = "نام جدول وارد شود")]
        [Display(Name ="نام جدول")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "نام جدول نمیتواند شامل اعداد باشد")]

        public string TableName { get; set; }
        
        
        public List<TypeList> TypeList { get { return _TypeList; } }

        private List<TypeList> _TypeList = new List<TypeList>();

    }
    public class TypeList
    {
        

        //[Required]

        public ColumnTypes Type { get; set; }

        [Required(ErrorMessage = "نام ستون وارد شود")]
       // [RegularExpression(@"[a-zA-Z]" , ErrorMessage ="نام ستون نمیتواند شامل اعداد باشد")]

        public string ColumnName { get; set; }

        public IEnumerable<SelectListItem> TypeSelectListItems
        {
            get
            {
                foreach (ColumnTypes type in Enum.GetValues(typeof(ColumnTypes)))
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = type.ToString();
                    selectListItem.Value = type.ToString();
                    selectListItem.Selected = Type == type;

                    yield return selectListItem;
                }
            }
        }
    }

}
