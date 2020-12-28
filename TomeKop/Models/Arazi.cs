using System;
using System.ComponentModel.DataAnnotations;

public class Arazi
{
    public int arazi_id { get; set; }
    public int uye_id { get; set; }
    [Required]
    public int parsel { get; set; }
    [Required]
    public int alan_m2 { get; set; }
    [Required]
    public string tapu_sahibi_tc_no { get; set; }
    [Required]
    public DateTime tapu_tarihi { get; set; }
}