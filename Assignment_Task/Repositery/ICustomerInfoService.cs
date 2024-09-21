using Assignment_Task.ViewModel;

namespace Assignment_Task.Repositery
{
    public interface ICustomerInfoService
    {
        Task<List<ListVM>> GetGenderList();
        Task<List<ListVM>> GetStateList();
        Task<List<ListVM>> GetDistrictList(int stateId);

        Task<ResponceVM> AddUpdateCustomer(CustomerInfoVM data);
        Task<List<CustomerInfoVM>> GetAllCustomers();
        Task<ResponceVM> DeleteCustomer(int  CustomerId);
        Task<CustomerInfoVM> GetCustomerById(int CustomerId);

    }
}
