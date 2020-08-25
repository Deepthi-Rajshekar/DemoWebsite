namespace TechnicalCourses.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<TechnicalCourses.Models.TechnicalCoursesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechnicalCourses.Models.TechnicalCoursesContext context)
        {
            context.Tutors.AddOrUpdate(x => x.Id,
                new Models.Tutor() { Id = 1, Name = "Java Tutorial" },
                new Models.Tutor() { Id = 2, Name = "Advance Java Tutorial" },
                new Models.Tutor() { Id = 3, Name = ".NET Tutorial" },
                new Models.Tutor() { Id = 4, Name = "C# Tutorial" },
                new Models.Tutor() { Id = 5, Name = "NodeJs Tutorial" },
                new Models.Tutor() { Id = 6, Name = "ReactJs Tutorial" },
                new Models.Tutor() { Id = 7, Name = "Docker Tutorial" },
                new Models.Tutor() { Id = 8, Name = "C++ Tutorial" },
                new Models.Tutor() { Id = 9, Name = "Python Tutorial" },
                new Models.Tutor() { Id = 10, Name = "Ubuntu Tutorial" },
                new Models.Tutor() { Id = 11, Name = "AngularJs Tutorial" },
                new Models.Tutor() { Id = 12, Name = "Ruby Tutorial" },
                new Models.Tutor() { Id = 13, Name = "PHP Tutorial" },
                new Models.Tutor() { Id = 14, Name = "DevOps Tutorial" },
                new Models.Tutor() { Id = 15, Name = "AWS Tutorial" }
                );
            context.Offices.AddOrUpdate(x => x.Officeid,
                new Models.Office()
                {
                    Officeid = 101,
                    Location = "Hyderabad",
                    TutorId = 1
                },
                new Models.Office()
                {
                    Officeid = 102,
                    Location = "Chennai",
                    TutorId = 2
                },
                new Models.Office()
                {
                    Officeid = 103,
                    Location = "Delhi",
                    TutorId = 3
                },
                new Models.Office()
                {
                    Officeid = 104,
                    Location = "Mumbai",
                    TutorId = 4
                },
                new Models.Office()
                {
                    Officeid = 105,
                    Location = "Hyderabad",
                    TutorId = 5
                },
                new Models.Office()
                {
                    Officeid = 106,
                    Location = "Hyderabad",
                    TutorId = 6
                },
                new Models.Office()
                {
                    Officeid = 107,
                    Location = "Chennai",
                    TutorId = 7
                },
                new Models.Office()
                {
                    Officeid = 108,
                    Location = "Delhi",
                    TutorId = 8
                },
                new Models.Office()
                {
                    Officeid = 109,
                    Location = "Delhi",
                    TutorId = 9
                },
                new Models.Office()
                {
                    Officeid = 110,
                    Location = "Mumbai",
                    TutorId = 10
                },
                new Models.Office()
                {
                    Officeid = 111,
                    Location = "Banglore",
                    TutorId = 11
                },
                new Models.Office()
                {
                    Officeid = 112,
                    Location = "Banglore",
                    TutorId = 12
                },
                new Models.Office()
                {
                    Officeid = 113,
                    Location = "Hyderabad",
                    TutorId = 13
                },
                new Models.Office()
                {
                    Officeid = 114,
                    Location = "Banglore",
                    TutorId = 14
                },
                new Models.Office()
                {
                    Officeid = 115,
                    Location = "Hyderabad",
                    TutorId = 15
                }
                );

        }
    }
}
