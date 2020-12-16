using System;
using System.ComponentModel.DataAnnotations;
using TomeKop.Utils;

public class Uye
{
    public int uye_id { get; set; }
    public int danisman_id { get; set; } = 0;

    [StringLength(11, ErrorMessage = "Tc Kimlik Numarası 11 haneli olmalıdır.")]
    public string tc_no { get; set; }
    public string adi { get; set; }
    public string soyadi { get; set; }
    public char cinsiyet { get; set; }

    [StringLength(10, ErrorMessage = "Telefon numarası 10 haneli olmalıdır.")]
    public string tel_no { get; set; }

    public DateTime dogum_tarihi { get; set; }

    [Required]
    public string email { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "Şifre is too long.")]
    public string login_password { get; set; }
}