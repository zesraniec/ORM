namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;
    
    public class Teacher : IEquatable<Teacher>
    {
        public Teacher(int id, string passport, string employmentContractNumber)
        {
            this.ID = id;
            this.Passport = passport.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(passport));
            this.EmploymentContractNumber = employmentContractNumber.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(employmentContractNumber));
        }
        
        [Obsolete("For ORM", true)]
        protected Teacher()
        {
        }
        public virtual int ID { get; protected set; }
        public virtual string Passport { get; protected set; }
        public virtual string EmploymentContractNumber { get; protected set; }
        public virtual string FullInfo => $"{this.Passport} {this.EmploymentContractNumber}".Trim();

        public virtual ISet<Class> Classes { get; protected set; } = new HashSet<Class>();

        public virtual bool AddClass(Class class1)
        {
            return class1 == null
                ? throw new ArgumentNullException(nameof(class1))
                : this.Classes.Add(class1);
        }

        public override string ToString() => this.FullInfo;

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || this.Equals(obj as Teacher));
        }

        public virtual bool Equals(Teacher other)
        {
            return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.ID == other.ID);
        }

        public override int GetHashCode() => this.ID;
    }
}

