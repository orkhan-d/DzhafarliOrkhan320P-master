//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DzhafarliOrkhan320P.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class requests
    {
        public int id { get; set; }
        public Nullable<int> code { get; set; }
        public string rnumber { get; set; }
    
        public virtual specs specs { get; set; }
    }
}
