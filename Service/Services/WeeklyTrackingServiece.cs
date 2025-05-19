
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
    public class WeeklyTrackingServiece : IService<WeeklyTrackingDto>
    {
        private readonly IRepository<WeeklyTracking> _repository;
        private readonly IMapper _mapper;

        public WeeklyTrackingServiece(IRepository<WeeklyTracking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public WeeklyTrackingDto AddItem(WeeklyTrackingDto item)
        {
            return _mapper.Map<WeeklyTracking, WeeklyTrackingDto>(_repository.AddItem(_mapper.Map<WeeklyTrackingDto, WeeklyTracking>(item)));
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
        }

        public List<WeeklyTrackingDto> GetAll()
        {
            return _mapper.Map<List<WeeklyTracking>, List<WeeklyTrackingDto>>(_repository.GetAll());
        }

        public WeeklyTrackingDto GetById(int id)
        {
            return _mapper.Map<WeeklyTracking, WeeklyTrackingDto>(_repository.GetById(id));
        }

        public void UpdateItem(int id, WeeklyTrackingDto item)
        {
            _repository.UpdateItem(id, _mapper.Map<WeeklyTrackingDto, WeeklyTracking>(item));
        }
    }
}
