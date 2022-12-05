using System.ComponentModel.DataAnnotations.Schema;

namespace ileriRepository.Data
{
    public class Personel:BaseInt
    {
        public string Name { get; set; }
        public string SurnameName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int DepartmentId { get; set; }
        public string GradeId { get; set; }
        public char Gender { get; set; }
        public string Street { get; set; }
        public string Avenue { get; set; }
        public string Phone { get; set; }
        public int No { get; set; }
        public int CountyId { get; set; }
        public string ImgUrl { get; set; }

        
        [ForeignKey("CountyId")]
        public County County { get; set; }

        [ForeignKey("GradeId")]
        public Grade Grade{ get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int GetAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - DateofBirth.Year;
            DateTime BirthDay=DateofBirth.AddDays(age);
            if(today < BirthDay)
            {
                age--;
            }
            return age;

        }
        public string Fullname()
        {
            if (Gender == 'E')
            {
                return $"Sn. Bay {Name} {SurnameName}";

            }
            else return $"Sn. Bayan {Name} {SurnameName}";
        }
        public List<string> GetAddress()
        {
            List<string> address = new List<string>();
            //address.Add(Fullname());
            address.Add(Street);
            address.Add(Avenue);
            address.Add(No.ToString());
            address.Add(County.CountyName + "/" + County.City.CityName);
            return address;


                
        }
       
    }
}
