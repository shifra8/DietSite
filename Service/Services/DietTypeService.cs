
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
    public class DietTypeService : IService<DietDto>
    {
        private readonly IRepository<DietType> _repository;
        private readonly IMapper _mapper;

        public DietTypeService(IRepository<DietType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public DietDto AddItem(DietDto item)
        {
            return _mapper.Map<DietType, DietDto>(_repository.AddItem(_mapper.Map<DietDto, DietType>(item)));
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<DietDto> GetAll()
        {
            return _mapper.Map<List<DietType>, List<DietDto>>(_repository.GetAll());
        }

        public DietDto GetById(int id)
        {
            return _mapper.Map<DietType, DietDto>(_repository.GetById(id));
        }

        public void UpdateItem(int id, DietDto item)
        {
            _repository.UpdateItem(id, _mapper.Map<DietDto, DietType>(item));
        }
        //כדאי לשנות לאסינכרוני וכן לעשות טיפול בשגיאות
    }
}
