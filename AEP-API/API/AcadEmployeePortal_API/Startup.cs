using ISMS_API.Data;
using ISMS_API.Helpers;
using ISMS_API.Services;
using ISMS_API.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ISMS_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.IsEssential = false;
                
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllers();
            //configure DBContext
            services.AddDbContext<EmpPortalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AEPDB")).EnableSensitiveDataLogging());
            //configure strongly typed settings objects
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<DaemonConfig>(appSettingSection);
            //add authentication configuration here

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ISS Express", Version = "v1" });
            });


            //NewtonsoftJson Config
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                
            //automapper config
            services.AddAutoMapper(typeof(Startup));
            //add dependency injection (DI) configuration here
            services.AddScoped<ICollegeService, CollegeService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeClassificationService, EmployeeClassificationService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IEvaluationCriteriaService, EvaluationCriteriaService>();
            services.AddScoped<IBarangayService, BarangayService>();
            services.AddScoped<ICourseTypeService, CourseTypeService>();
            services.AddScoped<ITeacherCourseScheduleService, TeacherCourseScheduleService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentCourseScheduleService, StudentCourseScheduleService>();
            services.AddScoped<IStudentGradesService, StudentGradesService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ICourseScheduleService, CourseScheduleService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IGradeRemarksService, GradeRemarksService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IEmployeeScheduleService, EmployeeScheduleService>();
            services.AddScoped<IEmployeeLeaveCreditsService, EmployeeLeaveCreditsService>();
            services.AddScoped<IDayService, DayService>();
            services.AddScoped<ILeaveApplicationService, LeaveApplicationService>();
            services.AddScoped<ILeaveApplicationStatusService, LeaveApplicationStatusService>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ICurriculumService, CurriculumService>();
            services.AddScoped<ICurriculumCourseService, CurriculumCourseService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPersonUserService, PersonUserService>();
            services.AddScoped<IDeanService, DeanService>();
            services.AddScoped<ITokenService, TokenService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ISMS_API v1"));
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {             
                endpoints.MapControllers();
            });           
            //app.UseMvc();
        }
    }
}