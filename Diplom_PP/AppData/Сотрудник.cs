//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom_PP.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сотрудник
    {
        public string ID { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public Nullable<int> ID_Отдел { get; set; }
        public Nullable<int> ID_Должность { get; set; }
        public string Телефон { get; set; }
        public string Email { get; set; }
    
        public virtual Должность Должность { get; set; }
        public virtual Отдел Отдел { get; set; }
    }
}
