//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp16
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public long Phone { get; set; }
        public Nullable<System.DateTime> BDay { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
