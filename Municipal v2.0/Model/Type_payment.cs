//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Municipal_v2._0.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Type_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type_payment()
        {
            this.HouseService = new HashSet<HouseService>();
        }
    
        public int payment_id { get; set; }
        public Nullable<int> service_id { get; set; }
        public string type_payment1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseService> HouseService { get; set; }
        public virtual Service Service { get; set; }
    }
}
