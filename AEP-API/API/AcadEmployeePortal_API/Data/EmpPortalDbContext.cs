using ISMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ISMS_API.Data
{
    public class EmpPortalDbContext: DbContext
    {
        public EmpPortalDbContext(DbContextOptions<EmpPortalDbContext> options): base(options)
        {
            
        }
        //add DB Sets here
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatus { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<CityMunicipality> CityMunicipalities { get; set; }
        public DbSet<CivilStatus> CivilStatus { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeDepartment> CollegeDepartments { get; set; }
        public DbSet<ConfirmationQuestion> ConfirmationQuestions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<CurriculumCourse> CurriculumCourses { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DesignationStatus> DesignationStatus { get; set; }
        public DbSet<DualCitizenshipAcquisition> DualCitizenshipAcquisitions { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet <EmployeeLeaveCredits> EmployeeLeaveCredits { get; set; }
        public DbSet<EmployeeClassification> EmployeeClassifications { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterion { get; set; }
        public DbSet<EvaluationItem> EvaluationItems { get; set; }
        public DbSet<EvaluationResponse> EvaluationResponses { get; set; }
        public DbSet<EvaluationResponseDetails> EvaluationResponseDetails { get; set; }       
        public DbSet<Gender> Gender { get; set; }
        public DbSet<GovernmentIssuedIdentification> GovernmentIssuedIdentifications { get; set; }
        public DbSet<GradeRemarks> GradeRemarks { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MidDay> MidDay { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonChild> PersonChildren { get; set; }
        public DbSet<PersonConfirmationQuestion> PersonConfirmationQuestions { get; set; }
        public DbSet<PersonEducationalBackground> PersonEducationalBackgrounds { get; set; }
        public DbSet<PersonOathDeclaration> PersonOathDeclarations { get; set; }
        public DbSet<PersonOrganizationMembershipInformation> PersonOrganizationMembershipInformations { get; set; }
        public DbSet<PersonParentsFamilyBackground> PersonParentsFamilyBackgrounds { get; set; }
        public DbSet<PersonRecognitionInformation> PersonRecognitionInformations { get; set; }
        public DbSet<PersonReference> PersonReferences { get; set; }
        public DbSet<PersonServiceEligibility> PersonServiceEligibilities { get; set; }
        public DbSet<PersonSkillsInformation> PersonSkillsInformations { get; set; }
        public DbSet<PersonSpouseFamilyBackground> PersonSpouseFamilyBackgrounds { get; set; }
        public DbSet<PersonTrainingProgram> PersonTrainingPrograms { get; set; }
        public DbSet<PersonUser> PersonUsers { get; set; }
        public DbSet<PersonVoluntaryWork> PersonVoluntaryWorks { get; set; }
        public DbSet<PersonWorkExperience> PersonWorkExperiences { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<ProgramMajor> ProgramMajors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Project> ResidentialCityMunicipalities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<RoleProject> RoleProjects { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrades> StudentGrades { get; set; }
        public DbSet<StudentCourseSchedule> StudentCourseSchedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourseSchedule> TeacherCourseSchedules { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TrainingProgramType> TrainingProgramTypes { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<LeaveApplicationStatus> LeaveApplicationStatus { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Event> Events { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CourseSchedule>().HasOne(m => m.MidDayTimeStart).WithMany(c => c.CourseScheduleMidDayIdTimeStart)
                                                 .HasForeignKey(m => m.MidDayIDTimeStart);
            modelBuilder.Entity<CourseSchedule>().HasOne(m => m.MidDayTimeEnd).WithMany(c => c.CourseScheduleMidDayIdTimeEnd)
                                                  .HasForeignKey(m => m.MidDayIDTimeEnd);            
            modelBuilder.RemovePluralizingTableNameConvention();
            
            
            
        }
    }
}