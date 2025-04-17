
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using EmployeeManagementSystem.DTO;


namespace EmployeeManagementSystem.Helpers
{
            public class EmployeePayrollPdfDocument : IDocument
                {
                    private readonly EmployeePayrollDTO _data;

                    public EmployeePayrollPdfDocument(EmployeePayrollDTO data)
                    {
                        _data = data;
                    }

                    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

                    public void Compose(IDocumentContainer container)
                    {
                        container.Page(page =>
                        {
                            page.Margin(30);
                            page.Size(PageSizes.A4);
                            page.PageColor(Colors.White);
                            page.DefaultTextStyle(x => x.FontSize(14));

                            page.Header().Text($"Payroll Report - Employee #{_data.EmployeeId}").SemiBold().FontSize(18).FontColor(Colors.Blue.Medium);

                            page.Content().PaddingVertical(10).Column(col =>
                            {
                                col.Item().Text($"Name: {_data.FirstName} {_data.LastName}");
                                col.Item().Text($"Payroll ID: {_data.PrId}");
                                col.Item().Text($"Base Salary: ₹{_data.BaseSalary}");
                                col.Item().Text($"Bonus: ₹{_data.Bonus}");
                                col.Item().Text($"Deductions: ₹{_data.Deductions}");
                                col.Item().Text($"Net Pay: ₹{_data.NetPay}");
                                col.Item().Text($"Pay Date: {_data.PayDate.ToString("dd MMM yyyy")}");
                            });

                            page.Footer().AlignCenter().Text(x =>
                            {
                                x.Span("Generated on ");
                                x.Span(DateTime.Now.ToString("dd MMM yyyy hh:mm tt")).SemiBold();
                            });
                        });
                    }
                }
}
