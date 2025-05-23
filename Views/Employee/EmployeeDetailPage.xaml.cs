using GeneralMAUI.ViewModels;

namespace GeneralMAUI.Views.Employee;

public partial class EmployeeDetailPage : ContentPage
{
	public EmployeeDetailPage()
	{
		InitializeComponent();

		var employeeDetailViewModel = new EmployeeDetailViewModel
		{
			EmployeeId="1001",
			EmployeeName="John",
			Email="jonh@ggg.com",
			IsPartTimer=true

		};
		BindingContext = employeeDetailViewModel;
	}
}