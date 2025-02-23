using Domain.Common;


namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int? Capacity {  get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
