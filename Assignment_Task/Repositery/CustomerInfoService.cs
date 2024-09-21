using Assignment_Task.Data;
using Assignment_Task.Models;
using Assignment_Task.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Task.Repositery
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly AppDBContext dBContext;

        #region Dropdown List
        public CustomerInfoService(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<List<ListVM>> GetStateList()
        {
            return await dBContext.StateMaster.OrderBy(x => x.Name)
             .Select(x => new ListVM
             {
                 Value = x.Id,
                 Text = x.Name,
             }).ToListAsync();

        }
        public async Task<List<ListVM>> GetDistrictList(int stateId)
        {
            return await dBContext.DistrictMaster.Where(x => x.StateId == stateId).
                OrderBy(x => x.Name).Select(x => new ListVM
                {
                    Text = x.Name,
                    Value = x.Id,
                }).ToListAsync();
        }
        public async Task<List<ListVM>> GetGenderList()
        {
            return await dBContext.Gender.OrderBy(x => x.Name).Select(x => new ListVM
            {
                Text = x.Name,
                Value = x.Id,
            }).ToListAsync();
        }
        #endregion
        #region Customer related details
        public async Task<ResponceVM> AddUpdateCustomer(CustomerInfoVM data)
        {
            if (data.CustomerId == 0)
            {
                var customer = new Customer_Info
                {
                    Name = data.Name,
                    GenderId = data.GenderId,
                    DistrictId = data.DistrictId,
                };
                var res = await dBContext.Customer_Info.AddAsync(customer);
                await dBContext.SaveChangesAsync();

                return new ResponceVM
                {
                    Status = 1,
                    MSG = "Customer Data Saved Successfully."
                };
            }
            else
            {
                var existingRecord = await dBContext.Customer_Info.FirstOrDefaultAsync(x => x.CustomerId == data.CustomerId);
                if (existingRecord != null)
                {
                    existingRecord.Name = data.Name;
                    existingRecord.GenderId = data.GenderId;
                    existingRecord.DistrictId = data.DistrictId;
                    await dBContext.SaveChangesAsync();
                    return new ResponceVM
                    {
                        Status = 1,
                        MSG = "Customer Data Updated Successfully."
                    };
                }
                else
                {
                    return new ResponceVM
                    {
                        Status = 1,
                        MSG = "Customer Data Not Found."
                    };
                }
            }

        }
        public async Task<List<CustomerInfoVM>> GetAllCustomers()
        {
            var lst = from c in dBContext.Customer_Info
                      join dst in dBContext.DistrictMaster on c.DistrictId equals dst.Id
                      join sm in dBContext.StateMaster on dst.StateId equals sm.Id
                      join g in dBContext.Gender on c.GenderId equals g.Id
                      select new CustomerInfoVM
                      {
                          Name = c.Name,
                          CustomerId = c.CustomerId,
                          GenderName = g.Name,
                          StateName = sm.Name,
                          DistrictName = dst.Name

                      };
            return await lst.ToListAsync();


        }

        public async Task<ResponceVM> DeleteCustomer(int CustomerId)
        {
            var res = new ResponceVM();
            var result = await dBContext.Customer_Info.FindAsync(CustomerId);
            if (result != null)
            {
                dBContext.Customer_Info.Remove(result);
                await dBContext.SaveChangesAsync();
                res.Status = 1;
                res.MSG = "Customer Deleted Successfully .";
            }
            else
            {
                res.Status = 0;
                res.MSG = "Customer not found.";
            }
            return res;
        }

        public async Task<CustomerInfoVM> GetCustomerById(int CustomerId)
        {
            var result = from c in dBContext.Customer_Info
                         join dst in dBContext.DistrictMaster on c.DistrictId equals dst.Id
                         join sm in dBContext.StateMaster on dst.StateId equals sm.Id
                         join g in dBContext.Gender on c.GenderId equals g.Id
                         where c.CustomerId == CustomerId
                         select new CustomerInfoVM
                         {
                             Name = c.Name,
                             CustomerId = c.CustomerId,
                             GenderId=c.GenderId,
                             StateId=sm.Id,
                             DistrictId=c.DistrictId,
                             GenderName = g.Name,
                             StateName = sm.Name,
                             DistrictName = dst.Name

                         };

            return await result.FirstOrDefaultAsync();
        }
    }
    #endregion

}
