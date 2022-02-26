namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class ClassMap : ClassMap<Class>
    {
        public ClassMap()
        {
            this.Table("Classes");

            this.Id(x => x.ID);

            this.Map(x => x.ClassName)
                .Not.Nullable();

            this.HasManyToMany(x => x.Teachers)
                .Cascade.Delete()
                .Inverse();
        }
    }
}
