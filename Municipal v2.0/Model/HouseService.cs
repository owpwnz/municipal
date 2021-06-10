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
    
    public partial class HouseService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HouseService()
        {
            this.Counter = new HashSet<Counter>();
            this.House_counter = new HashSet<House_counter>();
            this.House_public_utilities = new HashSet<House_public_utilities>();
            this.Individual_amount = new HashSet<Individual_amount>();
            this.Maintenance_and_repair = new HashSet<Maintenance_and_repair>();
            this.Public_utilities = new HashSet<Public_utilities>();
        }
    
        public int house_service_id { get; set; }
        public int house_id { get; set; }
        public Nullable<int> service_id { get; set; }
        public Nullable<double> rate { get; set; }
        public Nullable<int> payment_id { get; set; }
        public Nullable<double> norm { get; set; }
        public Nullable<int> device_id { get; set; }
        public Nullable<double> high_coef { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Counter> Counter { get; set; }
        public virtual Device Device { get; set; }
        public virtual House House { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House_counter> House_counter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House_public_utilities> House_public_utilities { get; set; }
        public virtual Service Service { get; set; }
        public virtual Type_payment Type_payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Individual_amount> Individual_amount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance_and_repair> Maintenance_and_repair { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Public_utilities> Public_utilities { get; set; }
    }
}
