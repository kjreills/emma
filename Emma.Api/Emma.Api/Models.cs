namespace Emma.Api
{
    public record Employee
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public DateOnly BirthDate { get; init; }
        public DateOnly HireDate { get; init; }
        public decimal Salary { get; init; }
        public Designation Designation { get; init; } = Designation.Empty;
        public Department Department { get; init; } = Department.Empty;
    }

    public record Designation
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;

        public static Designation Empty { get; } = new Designation();
    }

    public record Department
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;

        public static Department Empty { get; } = new Department();
    }
}
