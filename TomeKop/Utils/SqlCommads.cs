namespace TomeKop.Utils
{
    public class SqlCommands
    {
        // Üye işlemleri
        public static readonly string CheckIfUyelerTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'uyeler'";
        public static readonly string CreateUyeTable = @"CREATE TABLE uyeler (
                                                            uye_id SERIAL,
                                                            danisman_id INT DEFAULT 0,
                                                            tc_no CHAR(11) NOT NULL UNIQUE,
                                                            adi VARCHAR(15) NOT NULL, 
                                                            soyadi VARCHAR(15) NOT NULL,
                                                            cinsiyet CHAR,
                                                            tel_no CHAR(10),
                                                            dogum_tarihi DATE,
                                                            email VARCHAR(25) NOT NULL UNIQUE,
                                                            login_password VARCHAR(20) NOT NULL,
                                                            PRIMARY KEY (uye_id)
                                                        );";

        public static readonly string CreateUserLogin = "INSERT INTO uyeler (danisman_id, tc_no, adi, soyadi, cinsiyet, tel_no, dogum_tarihi, email, login_password) VALUES (@danisman_id, @tc_no, @adi, @soyadi, @cinsiyet, @tel_no, @dogum_tarihi, @email, @login_password);";
        public static readonly string UpdateUserLogin = "UPDATE uyeler SET danisman_id = @danisman_id, tc_no = @tc_no, adi = @adi, soyadi = @soyadi, cinsiyet = @cinsiyet, tel_no = @tel_no, dogum_tarihi = @dogum_tarihi, email = @email, login_password = @login_password WHERE uye_id = @uye_id;";
        public static readonly string DeleteUser = "DELETE FROM uyeler WHERE uye_id = @uye_id";
        public static readonly string CheckUserLogin = "SELECT * FROM uyeler WHERE email = @email AND login_password = @login_password;";
        public static readonly string SelectDanisman = "SELECT adi, soyadi, email, tel_no FROM uyeler WHERE uye_id = @uye_id;";
        public static readonly string UpdateUyeDanisman = "UPDATE uyeler SET danisman_id = @danisman_id WHERE uye_id = @uye_id;";

        // Adres İşlemleri
        public static readonly string CheckIfAdresTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'adresler'";
        public static readonly string CreateAdresTable = @"CREATE TABLE adresler (
                                                            adres_id SERIAL PRIMARY KEY,
                                                            uye_id INT,
                                                            il VARCHAR(13),
                                                            ilce VARCHAR(15),
                                                            mahalle VARCHAR(15),
                                                            adres VARCHAR(36),
                                                            FOREIGN KEY (uye_id) REFERENCES uyeler(uye_id) ON DELETE CASCADE
                                                        );";
        public static readonly string CreateAdres = "INSERT INTO adresler(uye_id, il, ilce, mahalle, adres) VALUES (@uye_id, @il, @ilce, @mahalle, @adres);";
        public static readonly string UpdateAdres = "UPDATE adresler SET il = @il, ilce = @ilce, mahalle = @mahalle, adres = @adres WHERE adres_id = @adres_id;";
        public static readonly string DeleteAdres = "DELETE FROM adresler WHERE adres_id = @adres_id;";
        public static readonly string SelectAdresler = "SELECT * FROM adresler WHERE uye_id = @uye_id;";

        // View İşlemleri
        public static readonly string CheckIfUyeViewExist = "SELECT * FROM information_schema.views WHERE table_schema = 'public' AND table_name = 'uye_view'";
        public static readonly string CreateUyeView = "CREATE OR REPLACE VIEW uye_view AS SELECT * FROM uyeler WHERE danisman_id > -1;";
        public static readonly string CheckIfDanismanViewExist = "SELECT * FROM information_schema.views WHERE table_schema = 'public' AND table_name = 'danisman_view'";
        public static readonly string CreateDanismanView = "CREATE OR REPLACE VIEW danisman_view AS SELECT adi, soyadi, email, tel_no FROM uyeler WHERE danisman_id = -1;";
        public static readonly string SelectUyeler = "SELECT * FROM uye_view;";
        public static readonly string SelectDanismanlar = "SELECT * FROM danisman_view;";

        // Sequence İşlemleri
        public static readonly string CreateAraziIdSeq = "CREATE SEQUENCE IF NOT EXISTS arazi_id_seq INCREMENT BY 2 START 2;";

        // Arazi İşlemleri
        public static readonly string CheckIfAraziTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'araziler'";
        public static readonly string CreateAraziTable = @"CREATE TABLE araziler (
                                                            arazi_id INT PRIMARY KEY,
                                                            uye_id INT,
                                                            parsel 	INT,
                                                            alan_m2 INT CHECK(alan_m2 > 100 AND alan_m2 < 100000),
                                                            tapu_sahibi_tc_no CHAR(11) NOT NULL,
                                                            tapu_tarihi DATE,
                                                            FOREIGN KEY (uye_id) REFERENCES uyeler(uye_id) ON DELETE CASCADE
                                                        );";
        public static readonly string CreateArazi = "INSERT INTO araziler(arazi_id, uye_id, parsel, alan_m2, tapu_sahibi_tc_no, tapu_tarihi) VALUES (nextval('arazi_id_seq'), @uye_id, @parsel, @alan_m2, @tapu_sahibi_tc_no, @tapu_tarihi);";
        public static readonly string UpdateArazi = "UPDATE araziler SET parsel = @parsel, alan_m2 = @alan_m2, tapu_sahibi_tc_no = @tapu_sahibi_tc_no, tapu_tarihi = @tapu_tarihi WHERE arazi_id = @arazi_id;";
        public static readonly string DeleteArazi = "DELETE FROM araziler WHERE arazi_id = @arazi_id;";
        public static readonly string SelectAraziler = "SELECT * FROM araziler WHERE uye_id = @uye_id;";
        public static readonly string SelectSumUyeAraziler = "SELECT u.uye_id, u.adi, u.soyadi, COALESCE(SUM(a.alan_m2), 0) AS alan_m2 FROM uyeler u LEFT JOIN araziler a ON a.uye_id = u.uye_id GROUP BY u.uye_id HAVING SUM(a.alan_m2) > @alan_m2;";

        // Ürün İşlemleri
        public static readonly string CheckIfUrunTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'urunler'";
        public static readonly string CreateUrunTable = @"CREATE TABLE urunler (
                                                            urun_id SERIAL NOT NULL,
                                                            urun_adi VARCHAR(15) NOT NULL,
                                                            cinsi VARCHAR(9),
                                                            miktar_ton NUMERIC(10,3),
                                                            alis_kg NUMERIC(10,3),
                                                            satis_kg NUMERIC(10,3),
                                                            uret_tarihi DATE,
                                                            uye_id INT,
                                                            PRIMARY KEY (urun_id),
                                                            FOREIGN KEY (uye_id) REFERENCES uyeler(uye_id) ON DELETE CASCADE
                                                        );";
        public static readonly string CreateUrun = "INSERT INTO urunler(urun_adi, uye_id, cinsi, miktar_ton, alis_kg, satis_kg, uret_tarihi) VALUES (@urun_adi, @uye_id, @cinsi, @miktar_ton, @alis_kg, @satis_kg, @uret_tarihi);";
        public static readonly string UpdateUrun = "UPDATE urunler SET urun_adi = @urun_adi, cinsi = @cinsi, miktar_ton = @miktar_ton, alis_kg = @alis_kg, satis_kg = @satis_kg, uret_tarihi = @uret_tarihi WHERE urun_id = @urun_id;";
        public static readonly string DeleteUrun = "DELETE FROM urunler WHERE urun_id = @urun_id;";
        public static readonly string SelectUrunler = "SELECT * FROM urunler WHERE uye_id = @uye_id;";
        public static readonly string SelectSumUyeUrunler = "SELECT u.uye_id, u.adi, u.soyadi, COALESCE(SUM(ur.miktar_ton), 0) AS miktar_ton FROM uyeler u LEFT JOIN urunler ur ON ur.uye_id = u.uye_id GROUP BY u.uye_id HAVING SUM(ur.miktar_ton) > @miktar_ton;";

    }
}