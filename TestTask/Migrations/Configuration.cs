namespace TestTask.Migrations
{
    using TestTask.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestTask.DAL;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTask.DAL.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(TestTask.DAL.BankContext context)
        {
            var clients = new List<Client>
            {
                new Client { FirstName = "Петр",   LastName = "Петров", INN = 123, clientType = "Физическое лицо",
                    DateOfRegister = DateTime.Parse("2010-09-01") },
                new Client { FirstName = "Иван", LastName = "Иванов", INN = 1234, clientType = "Юридическое лицо",
                    DateOfRegister = DateTime.Parse("2012-09-01") },
                new Client { FirstName = "Михаил",   LastName = "Моров", INN = 1235, clientType = "Физическое лицо",
                    DateOfRegister = DateTime.Parse("2013-09-01") },
                new Client { FirstName = "Юрий",    LastName = "Краснов", INN = 1236, clientType = "Физическое лицо",
                    DateOfRegister = DateTime.Parse("2012-09-01") },
                new Client { FirstName = "Дмитрий",      LastName = "Жилов", INN = 1237, clientType = "Юридическое лицо",
                    DateOfRegister = DateTime.Parse("2012-09-01") },
                new Client { FirstName = "Илья",    LastName = "Кереев", INN = 1238, clientType = "Физическое лицо",
                    DateOfRegister = DateTime.Parse("2011-09-01") },
                new Client { FirstName = "Кирилл",    LastName = "Ломов", INN = 1239, clientType = "Физическое лицо",
                    DateOfRegister = DateTime.Parse("2013-09-01") },
                new Client { FirstName = "Алексей",     LastName = "Алонов", INN = 12310, clientType = "Юридическое лицо",
                    DateOfRegister = DateTime.Parse("2005-08-11") }
            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var workers = new List<Worker>
            {
                new Worker { FirstMidName = "Георгий",     LastName = "Леонов",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Worker { FirstMidName = "Ваислий",    LastName = "Краев",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Worker { FirstMidName = "Дмитрий",   LastName = "Комунов",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Worker { FirstMidName = "Алексей", LastName = "Сидоров",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Worker { FirstMidName = "Евгений",   LastName = "Рогов",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            workers.ForEach(s => context.Workers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();


            var departments = new List<Department>
            {
                new Department { Title = "Город 1",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    WorkerID  = workers.SingleOrDefault( i => i.LastName == "Леонов").ID },
                new Department { Title = "Город 2", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    WorkerID  = workers.SingleOrDefault( i => i.LastName == "Краев").ID },
                new Department { Title = "Город 3", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    WorkerID  = workers.SingleOrDefault( i => i.LastName == "Комунов").ID },
                new Department { Title = "Город 4",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    WorkerID  = workers.SingleOrDefault( i => i.LastName == "Сидоров").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var organizations = new List<Organization>
            {
                new Organization {OrganizationID = 1050, Name = "Захаров Денис Дмитриевич",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 1").DepartmentID,
                  Workers = new List<Worker>()
                },
                new Organization {OrganizationID = 4022, Name = "Самойлов Святослав Вадимович",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 2").DepartmentID,
                  Workers = new List<Worker>()
                },
                new Organization {OrganizationID = 4041, Name = "Никонов Константин Григорьевич",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 2").DepartmentID,
                  Workers = new List<Worker>()
                },
                new Organization {OrganizationID = 3141, Name = "Городецкий Гавриил Евгеньевич",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 1").DepartmentID,
                  Workers = new List<Worker>()
                },
                new Organization {OrganizationID = 2021, Name = "Абрамов Юрий Александрович",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 3").DepartmentID,
                  Workers = new List<Worker>()
                },
                new Organization {OrganizationID = 2042, Name = "Грабчак Руслан Иванович",
                  DepartmentID = departments.SingleOrDefault( s => s.Title == "Город 4").DepartmentID,
                  Workers = new List<Worker>()
                },
            };
            organizations.ForEach(s => context.Organizations.AddOrUpdate(p => p.OrganizationID, s));
            context.SaveChanges();

            var offices = new List<Office>
            {
                new Office {
                    WorkerID = workers.SingleOrDefault( i => i.LastName == "Краев").ID,
                    Location = "Ленина 17" },
                new Office {
                    WorkerID = workers.SingleOrDefault( i => i.LastName == "Комунов").ID,
                    Location = "Строителей 27" },
                new Office {
                    WorkerID = workers.SingleOrDefault( i => i.LastName == "Сидоров").ID,
                    Location = "Проспект Мира 4" },
            };
            offices.ForEach(s => context.Offices.AddOrUpdate(p => p.WorkerID, s));
            context.SaveChanges();

            AddOrUpdateWorker(context, "Захаров Денис Дмитриевич", "Сидоров");
            AddOrUpdateWorker(context, "Самойлов Святослав Вадимович", "Рогов");

            AddOrUpdateWorker(context, "Никонов Константин Григорьевич", "Краев");
            AddOrUpdateWorker(context, "Городецкий Гавриил Евгеньевич", "Комунов");
            AddOrUpdateWorker(context, "Абрамов Юрий Александрович", "Леонов");
            AddOrUpdateWorker(context, "Грабчак Руслан Иванович", "Леонов");

            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Петров").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Захаров Денис Дмитриевич" ).OrganizationID,
                    Payed = Payed.YES
                },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Петров").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Самойлов Святослав Вадимович" ).OrganizationID,
                    Payed = Payed.YES
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Иванов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Никонов Константин Григорьевич" ).OrganizationID,
                    Payed = Payed.NO
                 },
                 new Enrollment {
                     ClientID = clients.SingleOrDefault(s => s.LastName == "Моров").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Городецкий Гавриил Евгеньевич" ).OrganizationID,
                    Payed = Payed.YES
                 },
                 new Enrollment {
                     ClientID = clients.SingleOrDefault(s => s.LastName == "Краснов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Абрамов Юрий Александрович" ).OrganizationID,
                    Payed = Payed.NO
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Краснов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Грабчак Руслан Иванович" ).OrganizationID,
                    Payed = Payed.NO
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Жилов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Захаров Денис Дмитриевич" ).OrganizationID,
                    Payed = Payed.YES
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Жилов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Самойлов Святослав Вадимович").OrganizationID,
                    Payed = Payed.NO
                 },
                new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Кереев").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Самойлов Святослав Вадимович").OrganizationID,
                    Payed = Payed.YES
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Ломов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Никонов Константин Григорьевич").OrganizationID,
                    Payed = Payed.YES
                 },
                 new Enrollment {
                    ClientID = clients.SingleOrDefault(s => s.LastName == "Алонов").ID,
                    OrganizationID = organizations.SingleOrDefault(c => c.Name == "Городецкий Гавриил Евгеньевич").OrganizationID,
                    Payed = Payed.YES
                 }
            };
            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Client.ID == e.ClientID &&
                         s.Organization.OrganizationID == e.OrganizationID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
        void AddOrUpdateWorker(BankContext context, string organizationName, string workerName)
        {
            var crs = context.Organizations.SingleOrDefault(c => c.Name == organizationName);
            var inst = crs.Workers.SingleOrDefault(i => i.LastName == workerName);
            if (inst == null)
                crs.Workers.Add(context.Workers.SingleOrDefault(i => i.LastName == workerName));
        }
    }
}