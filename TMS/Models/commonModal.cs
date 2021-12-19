namespace TMS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class commonModal : DbContext
    {
        public commonModal()
            : base("name=commonModal2")
        {
        }

        public virtual DbSet<Appointment_Days> Appointment_Days { get; set; }
        public virtual DbSet<Appointment_Times> Appointment_Times { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Bank_Information> Bank_Information { get; set; }
        public virtual DbSet<Blood_Group> Blood_Group { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Clinic_Information> Clinic_Information { get; set; }
        public virtual DbSet<Clinic_Time_Slabs> Clinic_Time_Slabs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreateUser> CreateUsers { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Doctor_Information> Doctor_Information { get; set; }
        public virtual DbSet<Doctor_Schedule> Doctor_Schedule { get; set; }
        public virtual DbSet<Email_Templates> Email_Templates { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Marital_Status> Marital_Status { get; set; }
        public virtual DbSet<New_Patient> New_Patient { get; set; }
        public virtual DbSet<ProcessAppointment> ProcessAppointments { get; set; }
        public virtual DbSet<Regular_Patient> Regular_Patient { get; set; }
        public virtual DbSet<ResetPassword> ResetPasswords { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Staff_Information> Staff_Information { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Status_Referance> Status_Referance { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment_Times>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment_Times>()
                .Property(e => e.Clinic_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Bank_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Acronym)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Branch_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Phone_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Bank_Information>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Blood_Group>()
                .Property(e => e.Blood_Group_Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.City_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Acronym)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.NTN_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Contact)
                .IsFixedLength();

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Time_Start)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Time_End)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Information>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic_Time_Slabs>()
                .Property(e => e.Clinic_Time_Slabs1)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Country_Name)
                .IsUnicode(false);

            modelBuilder.Entity<CreateUser>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<CreateUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Disease>()
                .Property(e => e.Disease_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.PMDC_No)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.CNIC_No)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Cell_No)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Home_Ph_No)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Postal_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Account_Information)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Fee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Doctor_Information>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<Email_Templates>()
                .Property(e => e.Template_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Email_Templates>()
                .Property(e => e.Email_Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Email_Templates>()
                .Property(e => e.Email_Body)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Gender_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Marital_Status>()
                .Property(e => e.Marital_Status_Name)
                .IsUnicode(false);

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.Full_Name)
                .IsUnicode(false);

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.Contact)
                .IsFixedLength();

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.CNIC)
                .IsUnicode(false);

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<New_Patient>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ProcessAppointment>()
                .Property(e => e.Amount_Recieved)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProcessAppointment>()
                .Property(e => e.Prescription)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Contact)
                .IsFixedLength();

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.CNIC)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Discription)
                .IsUnicode(false);

            modelBuilder.Entity<Regular_Patient>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ResetPassword>()
                .Property(e => e.User_email)
                .IsUnicode(false);

            modelBuilder.Entity<ResetPassword>()
                .Property(e => e.Request_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Service_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Speciality>()
                .Property(e => e.Speciality_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.CNIC_No)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.Cell_No)
                .IsUnicode(false);

            modelBuilder.Entity<Staff_Information>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.State_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status_Referance>()
                .Property(e => e.Reference_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Status_Referance>()
                .Property(e => e.Reference_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Status_Referance>()
                .Property(e => e.Reference_Desc)
                .IsUnicode(false);
        }
    }
}
