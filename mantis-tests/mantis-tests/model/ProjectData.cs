using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData()
        {

        }

        public ProjectData(string name)
        {
            Name = name;
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }


        public static List<ProjectData> GetAll()
        {
            using (BugtrackerDB db = new BugtrackerDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }
    }
}
