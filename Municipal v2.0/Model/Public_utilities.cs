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
    
    public partial class Public_utilities
    {
        public int public_utilities_id { get; set; }
        public Nullable<int> counter_id { get; set; }
        public float used { get; set; }
        public Nullable<decimal> recalculation { get; set; }
        public Nullable<decimal> amount_pay { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> house_service_id { get; set; }
        public int personal_id { get; set; }
        public Nullable<double> size_high_coef { get; set; }
        public Nullable<decimal> amount_high_coef { get; set; }
        public Nullable<decimal> benefit { get; set; }
        public decimal amount { get; set; }
    
        public virtual Counter Counter { get; set; }
        public virtual HouseService HouseService { get; set; }
        public virtual Personal_account Personal_account { get; set; }
    }
}