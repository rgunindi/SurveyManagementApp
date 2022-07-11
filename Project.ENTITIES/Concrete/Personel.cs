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
        public DateTime BornDate { get; set; }
        public string PersonelPassword { get; set; }
        public string LoginCheck=>PersonelName+PersonelSurname+BornDate.ToString("yyyy-MM-dd");
        public Role Role { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public string CurrentComp => $"{PersonelName} {PersonelSurname} " +
            $"[{CoalesceException(()=>Company.CompanyName,"unassigned")}] - [{(Role == 0 ? "Personel" : "Manager")}]";

    public static T CoalesceException<T>(Func<T> func, T defaultValue = default)
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