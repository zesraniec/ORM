namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Staff.Extensions;
    public class Class
    {
        public Class(int id, string className, params Teacher[] teachers)
            : this(id, className, new HashSet<Teacher>(teachers))
        {
        }

        public Class(int id, string className, ISet<Teacher> teachers = null)
        {
            this.ID = id;
            this.ClassName = className.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(className));

            foreach (var teacher in teachers ?? Enumerable.Empty<Teacher>())
            {
                this.Teachers.Add(teacher);
                teacher.AddClass(this);
            }
        }

        [Obsolete("For ORM", true)]
        protected Class()
        {
        }

        public virtual int ID { get; protected set; }
        public virtual string ClassName { get; protected set; }
        public virtual ISet<Teacher> Teachers { get; protected set; } = new HashSet<Teacher>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.ClassName} {this.Teachers.Join()}".Trim();

    }
}
