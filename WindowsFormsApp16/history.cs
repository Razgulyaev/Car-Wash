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
    
    public partial class history
    {
        public int Id { get; set; }
        public int Number_Box { get; set; }
        public System.DateTime Data_Time_Box { get; set; }
        public int FK_Service { get; set; }
    
        public virtual Box Box { get; set; }
        public virtual Service Service { get; set; }
    }
}