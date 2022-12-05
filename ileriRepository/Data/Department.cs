namespace ileriRepository.Data
{
    public class Department:BaseInt
    {
        public string DepartmentName { get; set; }
        public ICollection<Personel> Personels { get; set; } //bir departmanda birden fazla personel olabilir.
    }
}
