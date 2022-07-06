using Project.ENTITIES.Concrete;

namespace Project.ENTITIES
{
    internal class Personel
    {
        public int PersonelID { get; set; }
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }
        public System.DateTime BornDate { get; set; }
        public string PersonelPassword { get; set; }
        public Role Role { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}