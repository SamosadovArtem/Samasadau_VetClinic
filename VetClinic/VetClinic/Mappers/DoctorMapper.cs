using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VetClinic.Models;
using VetClinic.Models.ViewModels;

namespace VetClinic.Mappers
{
    public class DoctorMapper : IMapper
    {
        static DoctorMapper()
        {
            Mapper.CreateMap<Doctor, DoctorView>();
            Mapper.CreateMap<DoctorView, Doctor>();
            Mapper.CreateMap<Client, ClientView>();
            Mapper.CreateMap<ClientView, Client>();
            Mapper.CreateMap<PetView, Pet>();
            Mapper.CreateMap<Pet, PetView>();
            Mapper.CreateMap<ScheduleView, Schedule>();
            Mapper.CreateMap<Schedule, ScheduleView>();
            Mapper.CreateMap<RecallView, Recall>();
            Mapper.CreateMap<ProcedureView, Procedure>();
            Mapper.CreateMap<Procedure, ProcedureView>();

        }
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

    }
}