namespace EmployeeManagementSystem.DTO
{
    public class PayrollDTO
    {
        public int PrId { get; set; }
        public double BaseSalary { get; set; }
        public double? Bonus { get; set; }
        public double? Deductions { get; set; }
        public double Netpay { get; set; }
        public DateOnly PayDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
