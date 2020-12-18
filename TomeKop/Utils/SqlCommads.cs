namespace TomeKop.Utils
{
    public class SqlCommands
    {
        // Üye işlemleri
        public static readonly string CheckIfUyelerTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'uyeler'";
        public static readonly string CreateUyeTable = @"CREATE TABLE uyeler (
                                                            uye_id SERIAL NOT NULL,
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
                                                            adres_id SERIAL NOT NULL PRIMARY KEY,
                                                            uye_id INT NOT NULL,
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

    }
}