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
    
    public partial class Receipt
    {
        public int receipt_id { get; set; }
        public int personal_id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> debt { get; set; }
        public decimal amount_to_pay { get; set; }
        public Nullable<decimal> penalties { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.DateTime> date_pay { get; set; }
        public Nullable<decimal> amount_paid { get; set; }
        public Nullable<System.DateTime> date_pay_before { get; set; }
        public Nullable<decimal> overpayment { get; set; }
        public Nullable<System.DateTime> last_payment_date { get; set; }
    
        public virtual Personal_account Personal_account { get; set; }
    }
}
