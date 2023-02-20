using AutoMapper;
using ISMS_API.DTOs;
using ISMS_API.Models;

namespace ISMS_API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Maps Employee to Employee DTO Model
            CreateMap<Employee, EmployeeDto>()
             .ForMember(dest => dest.EmployeeNo, opt => opt.MapFrom(src => src.EmployeeNo == null ? "N/A" : src.EmployeeNo))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.DesignationStatus, opt => opt.MapFrom(src => src.DesignationStatus.DesignationStatusDescription == null ? "N/A" : src.DesignationStatus.DesignationStatusDescription))
            .ForMember(dest => dest.EmployeeClassificationDescription, opt => opt.MapFrom(src => src.EmployeeClassification.EmployeeClassificationDescription == null ? "N/A" : src.EmployeeClassification.EmployeeClassificationDescription));
            
            //Maps User to User DTO model
            CreateMap<User, UserDto>()            
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            
            //Maps AddressType to AddressTypeDto
            CreateMap<AddressType, AddressTypeDto>()
                .ForMember(dest => dest.AddressTypeName, opt => opt.MapFrom(src => src.AddressTypeName))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
            
            //Maps Address to AddressDto Model
            CreateMap<Address, AddressDto>()               
                .ForMember(dest => dest.AddressID, opt => opt.MapFrom(src => src.AddressId))
               .ForMember(dest => dest.AddressTypeName, opt => opt.MapFrom(src => src.AddressType))
                .ForMember(dest => dest.HouseBlkLotNo, opt => opt.MapFrom(src => src.HouseBlkLotNo))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.SubdivisionVillage, opt => opt.MapFrom(src => src.SubdivisionVillage))
                .ForMember(dest => dest.Barangay, opt => opt.MapFrom(src => src.Barangay.BarangayName))
                .ForMember(dest => dest.CityMunicipality, opt => opt.MapFrom(src => src.CityMunicipality.CityMunicipalityName))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province.ProvinceName))
                
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

            CreateMap<Programs, ProgramDto>()
                  .ForMember(dest => dest.ProgramName, opt => opt.MapFrom(src => src.ProgramName))
                  .ForMember(dest => dest.ProgramCode, opt => opt.MapFrom(src => src.ProgramCode))
                  .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));
             //Maps Major to Major DTO   
            CreateMap<Major, MajorDto>();

            //Maps Semester DTO to Semester Model
            CreateMap<Semester, SemesterDto>()
                .ForMember(dest => dest.SemesterId, opt => opt.MapFrom(src => src.SemesterId))
                .ForMember(dest => dest.SemesterCode, opt => opt.MapFrom(src => src.SemesterCode))
                .ForMember(dest => dest.SemesterName, opt => opt.MapFrom(src => src.SemesterName));

            //Maps StudentCourseSchedule to StudentCourseSchedule DTO
            CreateMap<StudentCourseSchedule, StudentCourseSchedulesDto>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseScheduleId, opt => opt.MapFrom(src => src.CourseScheduleId))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.CourseSchedules, opt => opt.MapFrom(src => src.CourseSchedules));

            //Maps TeacherCourseSchedule to TeacherCourseSchedule DTO Model
            CreateMap<TeacherCourseSchedule, TeacherCourseSchedulesDto>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.CourseScheduleId, opt => opt.MapFrom(src => src.CourseScheduleId))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.CourseSchedules, opt => opt.MapFrom(src => src.CourseSchedule));

            //Maps Person to Person DTO Model
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.FirstName
                + ", " + src.LastName + (src.MiddleName == null ? "" : " " + src.MiddleName)
                + (" " + src.NameExtension == null ? "" : src.NameExtension)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.GenderName))
                .ForMember(dest => dest.CivilStatus, opt => opt.MapFrom(src => src.CivilStatus.CivilStatusType == null ? "N/A" : src.CivilStatus.CivilStatusType))
                .ForMember(dest => dest.Citizenship, opt => opt.MapFrom(src => src.Citizenship.CitizenshipStatus == null ? "N/A" : src.Citizenship.CitizenshipStatus))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.TelephoneNo, opt => opt.MapFrom(src => src.TelephoneNo == null ? "N/A" : src.TelephoneNo))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => src.MobileNo == null ? "N/A" : src.MobileNo))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress == null ? "N/A" : src.EmailAddress))
                .ForMember(dest => dest.PictureLink, opt => opt.MapFrom(src => src.PictureLink))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));

            //Maps Student to Student DTO Model
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID))
                .ForMember(dest => dest.StudentNo, opt => opt.MapFrom(src => src.StudentNo))
                .ForMember(dest => dest.LRNNo, opt => opt.MapFrom(src => src.LRNNo))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.Program, opt => opt.MapFrom(src => src.Program))
                .ForMember(dest => dest.MajorName, opt => opt.MapFrom(src => src.Major.MajorName))
                .ForMember(dest => dest.YearLevel, opt => opt.MapFrom(src => src.YearLevel))
                .ForMember(dest => dest.StudentSchedules, opt => opt.MapFrom(src => src.StudentSchedules));

            //Maps Dean to Dean DTO Model
            CreateMap<Dean, DeanDto>()
                .ForMember(dest => dest.DeanID, opt => opt.MapFrom(src => src.DeanID))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.College, opt => opt.MapFrom(src => src.College));

            //Maps Teacher to Teacher DTO Model
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.College, opt => opt.MapFrom(src => src.College))
                .ForMember(dest => dest.CourseSchedules, opt => opt.MapFrom(src => src.TeacherCourseSchedules));

            //Maps College to College DTO Model
            CreateMap<College, CollegeDto>()
                .ForMember(dest => dest.CollegeID, opt => opt.MapFrom(src => src.CollegeID))
                .ForMember(dest => dest.CollegeName, opt => opt.MapFrom(src => src.CollegeName))
                .ForMember(dest => dest.CollegeCode, opt => opt.MapFrom(src => src.CollegeCode))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers));
            //Maps Course to Course DTO Model
            CreateMap<Course, CourseDto>()
               .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.CourseID))
               .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
               .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.CourseDescription))
               .ForMember(dest => dest.Units, opt => opt.MapFrom(src => src.Units))
               .ForMember(dest => dest.NoOfHours, opt => opt.MapFrom(src => src.NoOfHours))
               .ForMember(dest => dest.CourseTypeName, opt => opt.MapFrom(src => src.CourseType.CourseTypeName));

            //Maps CourseSchedule to CourseSchedule DTO Model
            CreateMap<CourseSchedule, CourseSchedulesDto>()
                .ForMember(dest => dest.CourseScheduleId, opt => opt.MapFrom(src => src.CourseScheduleId))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))             
               .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day.DayName))
               .ForMember(dest => dest.TimeStart, opt => opt.MapFrom(src => src.TimeStart))
               .ForMember(dest => dest.MidDayTimeStart, opt => opt.MapFrom(src => src.MidDayTimeStart.MidDayName))
               .ForMember(dest => dest.TimeEnd, opt => opt.MapFrom(src => src.TimeEnd))
               .ForMember(dest => dest.MidDayTimeEnd, opt => opt.MapFrom(src => src.MidDayTimeEnd.MidDayName))
               .ForMember(dest => dest.StudentSchedules, opt => opt.MapFrom(src => src.StudentCourseSchedules))
               .ForMember(dest => dest.TeacherSchedules, opt => opt.MapFrom(src => src.TeacherCourseSchedules));
            
            //Maps Room to Room DTO Model
            CreateMap<Room, RoomDto>()
                 .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.RoomTypeName))
                  .ForMember(dest => dest.RoomTypeDescription, opt => opt.MapFrom(src => src.RoomType.RoomTypeDescription));
            
            //Maps Term DTO to Term Model
            CreateMap<Term, TermDto>();
                     
        }
    }
}
