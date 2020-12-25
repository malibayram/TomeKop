using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Uye
{
    [JsonPropertyName("uye_id")]
    public int uye_id { get; set; }
    [JsonPropertyName("danisman_id")]
    public int danisman_id { get; set; } = 0;

    [JsonPropertyName("tc_no")]
    [StringLength(11, ErrorMessage = "Tc Kimlik Numarası 11 haneli olmalıdır.")]
    public string tc_no { get; set; }
    [JsonPropertyName("adi")]
    public string adi { get; set; }
    [JsonPropertyName("soyadi")]
    public string soyadi { get; set; }
    [JsonPropertyName("cinsiyet")]
    public char cinsiyet { get; set; }
    [JsonPropertyName("tel_no")]

    [StringLength(10, ErrorMessage = "Telefon numarası 10 haneli olmalıdır.")]
    public string tel_no { get; set; }
    [JsonPropertyName("dogum_tarihi")]

    public DateTime dogum_tarihi { get; set; }
    [JsonPropertyName("email")]

    [Required]
    public string email { get; set; }
    [JsonPropertyName("login_password")]

    [Required]
    [StringLength(20, ErrorMessage = "Şifre is too long.")]
    public string login_password { get; set; }
}