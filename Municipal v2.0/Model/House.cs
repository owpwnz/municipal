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
    
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            this.Apartment = new HashSet<Apartment>();
            this.House_counter = new HashSet<House_counter>();
            this.HouseService = new HashSet<HouseService>();
            this.Individual_amount = new HashSet<Individual_amount>();
        }
    
        public int house_id { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string house1 { get; set; }
        public Nullable<double> square_residental { get; set; }
        public Nullable<double> square_nonresidental { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apartment> Apartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<House_counter> House_counter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseService> HouseService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Individual_amount> Individual_amount { get; set; }
    }
}