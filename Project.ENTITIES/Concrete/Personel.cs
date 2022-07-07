using System;
using System.ComponentModel.DataAnnotations;

namespace Project.ENTITIES.Concrete
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [StringLength(20)]
        [Required]
        public string PersonelName { get; set; }
        [StringLength(20)]
        [Required]
        public string PersonelSurname { get; set; }
        public string FullName => PersonelName + " " + PersonelSurname;

        public System.DateTime BornDate { get; set; }
        public string PersonelPassword { get; set; }
        public Role Role { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public string CurrentComp => $"{PersonelName} {PersonelSurname} " +
            $"[{CoalesceException(()=>Company.CompanyName,"unassigned")}] - [{(Role == 0 ? "Personel" : "Manager")}]";

    public static T CoalesceException<T>(Func<T> func, T defaultValue = default(T))
    {
        try
        {
            return func();
        }
        catch
        {
            return defaultValue;
        }
    }
    }
    public enum Role
    {
        Personel,
        Manager
    }
}