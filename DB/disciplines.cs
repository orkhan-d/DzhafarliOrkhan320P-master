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
    
    public partial class disciplines
    {
        public int code { get; set; }
        public Nullable<int> hours { get; set; }
        public string dname { get; set; }
        public string kafedra_code { get; set; }
    
        public virtual kafedras kafedras { get; set; }
    }
}
