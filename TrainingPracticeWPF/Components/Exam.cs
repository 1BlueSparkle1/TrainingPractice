//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingPracticeWPF.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateExam { get; set; }
        public Nullable<int> CodeDiscipline { get; set; }
        public Nullable<int> RegistrationNumberStudent { get; set; }
        public Nullable<int> TabNumberEmployee { get; set; }
        public string Audience { get; set; }
        public Nullable<int> Appraisal { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
    }
}
