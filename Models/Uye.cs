using System;
using System.ComponentModel.DataAnnotations;

public class Uye
{
    public int Id { get; set; }
    /* [Required] */
    public string IsimSoyisim { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "Şifre is too long.")]
    public string Sifre { get; set; }

    /* [Range(typeof(DateTime), "1/1/1970", "12/31/2002", ErrorMessage = "Value for {0} must be between {1} and {2}")] */
    public DateTime DogumTarihi { get; set; }
    public Int16 Cinsiyet { get; set; }
    /* [Required] */
    [StringLength(10, ErrorMessage = "Telephone number is too long.")]
    public string TelNo { get; set; }
    /* [Required] */
    [StringLength(11, ErrorMessage = "National identity number is too long.")]
    public string TcNo { get; set; }
}