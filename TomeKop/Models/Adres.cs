using System.ComponentModel.DataAnnotations;

public class Adres
{
    public int adres_id { get; set; }
    public int uye_id { get; set; }
    [Required]
    public string il { get; set; }
    [Required]
    public string ilce { get; set; }
    [Required]
    public string mahalle { get; set; }
    [Required]
    public string adres { get; set; }
}