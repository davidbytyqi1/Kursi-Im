using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.Administrations
{
    public  class ExportContractData
    {

        public string CompanyName { get; set; }
        public string CompanyPlace { get; set; }
        public string CompanyAddress { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePersonalNumber { get; set; }
        public string EmployeeQualification { get; set; }
        public string EmployeeAddress { get; set; }
        public string StartContractualDate { get; set; }
        public string EndContractualDate { get; set; }
        public string StartUnspecifiedContractualDate { get; set; }
        public string StartEmployeeDate { get; set; }
        public string ProbationaryWork { get; set; }
        public string DailyHours { get; set; }
        public string WeeklyHours { get; set; }
        public string GrossSalary { get; set; }
        public string DesignationWork { get; set; }
        public string NatureWork { get; set; }
        public string WorkType { get; set; }
        public string WorkDescription { get; set; }
        public int VacationDaysLeft { get; set; }
        public int VacationYear { get; set; }
        public string TodayDate { get; set; }
    }
}
