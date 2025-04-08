using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementDto;
using SchoolManagementModel.MolderFolder;
using SchoolMangementDto;

namespace schoolManagementBussenesslogic.MapperProfileFolder
{
    public class MapperProfileClass:Profile
    {
        public MapperProfileClass()
        {
            CreateMap<TeachersModel, TeacherDto>()
                .ForMember(d => d.TeacherId, a => a.MapFrom(s => s.Id))
                .ForMember(d => d.TeacherName, a => a.MapFrom(s => s.Name))
                .ForMember(d => d.TeacherEmail, a => a.MapFrom(s => s.Email))
                .ForMember(d => d.TeacherPhone, a => a.MapFrom(s => s.Phone)).ReverseMap();


            CreateMap<StudentModel, StudentDto>()
               .ForMember(d => d.Stid, a => a.MapFrom(s => s.id))
               .ForMember(d => d.StuName, a => a.MapFrom(s => s.Name))
               .ForMember(d => d.StuAddress, a => a.MapFrom(s => s.Address))
               .ForMember(d => d.StuClass, a => a.MapFrom(s => s.Class)).ReverseMap();
        }
    }
}
