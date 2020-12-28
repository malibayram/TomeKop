using System;
using System.ComponentModel.DataAnnotations;

public class Urun
{
    public int urun_id { get; set; }
    public int uye_id { get; set; }
    [Required]
    public string urun_adi { get; set; }
    [Required]
    public string cinsi { get; set; }
    [Required]
    public double miktar_ton { get; set; }
    [Required]
    public double alis_kg { get; set; }
    [Required]
    public double satis_kg { get; set; }
    [Required]
    public DateTime uret_tarihi { get; set; }
}