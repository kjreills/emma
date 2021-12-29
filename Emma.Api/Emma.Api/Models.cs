namespace Summit.Api
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public DateOnly HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }

    public class Designation
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
