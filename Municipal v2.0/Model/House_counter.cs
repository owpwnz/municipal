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
    
    public partial class House_counter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House_counter()
        {
            this.House_public_utilities = new HashSet<House_public_utilities>();
        }
    
        public int house_counter_id { get; set; }
        public int house_id { get; set; }
        public int service_id { get; set; }
        public Nullable<double> indication { get; set; }
    
        public virtual House House { get; set; }
        public virtual HouseService HouseService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House_public_utilities> House_public_utilities { get; set; }
    }
}
