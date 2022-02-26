namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class TeacherMap : ClassMap<Teacher>
    {
        public TeacherMap()
        {
            this.Table("Teachers");

            this.Id(x => x.ID);

            this.Map(x => x.Passport)
                .Not.Nullable();

            this.Map(x => x.EmploymentContractNumber)
                .Not.Nullable();

            this.HasManyToMany(x => x.Classes)
                .Cascade.Delete();
        }
    }
}

