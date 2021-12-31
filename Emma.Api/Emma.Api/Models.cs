namespace Emma.Api
{
    public record Employee
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateTime BirthDate { get; init; }
        public DateTime HireDate { get; init; }
        public decimal Salary { get; init; }

        public Designation Designation { get; init; } = new Designation();
        public Department Department { get; init; } = new Department();
    }

    public record Designation
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
    }

    public record Department
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }

    public record Error(string Message);
}
