//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace DirectoryBook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Name
    {
      
    
        public int Id { get; set; }



         [Display(Name = "Name")]
         [Required(ErrorMessage = "The field must be set")]
         [StringLength(20, MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 20 characters")]
         public string TName { get; set; }


          [Display(Name = "Surname")]
          [Required(ErrorMessage = "The field must be set")]
          [StringLength(20, MinimumLength = 3, ErrorMessage = "The string length must be between 3 and 20 characters")]
          public string Surname { get; set; }
    
        public virtual ICollection<Phone> Phones { get; set; }
    }
}