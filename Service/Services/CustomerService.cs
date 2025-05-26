
using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerService : IService<CustomerDto>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CustomerDto AddItem(CustomerDto item)
        {
            return _mapper.Map<Customer, CustomerDto>(_repository.AddItem(_mapper.Map<CustomerDto, Customer>(item)));
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<CustomerDto> GetAll()
        {
            return _mapper.Map<List<Customer>, List<CustomerDto>>(_repository.GetAll());
        }

        public CustomerDto GetById(int id)
        {
            return _mapper.Map<Customer, CustomerDto>(_repository.GetById(id));
        }

        public void UpdateItem(int id, CustomerDto item)
        {
            _repository.UpdateItem(id, _mapper.Map<CustomerDto, Customer>(item));
        }

        public void UpdateItem(int id, WeeklyTrackingDto weeklyTrackingDto)
        {
            throw new NotImplementedException();
        }
    }
}
