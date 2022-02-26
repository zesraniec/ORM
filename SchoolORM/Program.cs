namespace Demo
{
    using System;
    using System.Linq;
    using DataAccess;
    using DataAccess.Repositories;
    using Domain;

    internal class Program
    {
        private static void Main()
        {
            var teacher = new Teacher(1, "pasnumber 0000 00001", "contnumber 001");
            var teacher1 = new Teacher(2, "pasnumber 0000 00002", "contnumber 002");
            var teacher2 = new Teacher(3, "pasnumber 0000 00003", "contnumber 003");
            var teacher3 = new Teacher(4, "pasnumber 0000 00004", "contnumber 004");

            var class1 = new Class(1, "1-A", teacher);
            var class2 = new Class(1, "2-Б", teacher1);
            var class3 = new Class(1, "3-В", teacher2);
            var class4 = new Class(1, "4-Г", teacher3);

            Console.WriteLine($"{class1} {teacher}");

            var settings = new Settings();

            settings.AddDatabaseServer(@"LAPTOP-57BV0I6T\SQLEXPRESS");

            settings.AddDatabaseName("ClassServer");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                session.Save(class1);
                session.Save(class2);
                session.Save(class3);
                session.Save(class4);

                session.Save(teacher);
                session.Save(teacher1);
                session.Save(teacher2);
                session.Save(teacher3);
                session.Flush();
            }

            using (var session = sessionFactory.OpenSession())
            {
                var repoClass = new ClassRepository();
                Console.WriteLine("All classes:");
                repoClass.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));

                var repoTeacher = new TeacherRepository();
                Console.WriteLine("All teachers:");
                repoTeacher.GetAll(session)
                    .ToList().ForEach(Console.WriteLine);
                Console.WriteLine(new string('-', 25));
            }
        }
    }
}
