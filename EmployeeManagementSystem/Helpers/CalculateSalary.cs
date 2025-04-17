namespace EmployeeManagementSystem.Helpers
{
    public class CalculateSalary
    {
        /// <summary>
        /// Calculates the bonus percentage based on the bonus amount and base salary.
        /// </summary>
        /// <param name="bonus">Bonus amount.</param>
        /// <param name="baseSalary">Base salary of the employee.</param>
        /// <returns>Bonus percentage (e.g., 10 means 10%).</returns>
        public double BonusCalculation(double bonus, double baseSalary)
        {
            if (baseSalary <= 0)
                return 0;

            return Math.Round((bonus / baseSalary) * 100, 2);
        }

        /// <summary>
        /// Calculates the net pay after applying bonus and deductions.
        /// </summary>
        /// <param name="baseSalary">Base salary.</param>
        /// <param name="bonus">Bonus amount.</param>
        /// <param name="deductions">Deductions (e.g., tax).</param>
        /// <returns>Total net pay.</returns>
        public double CalculateNetPay(double baseSalary, double? bonus, double? deductions)
        {
            return baseSalary + (bonus ?? 0) - (deductions ?? 0);
        }
    }
}
