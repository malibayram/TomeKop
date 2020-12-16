namespace TomeKop.Utils
{
    public class SqlCommands
    {
        public static readonly string CheckIfUyelerTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'uyeler'";
        public static readonly string CreateUyeTable = @"CREATE TABLE uyeler (
                                                            UYE_ID SERIAL NOT NULL,
                                                            DANISMAN_ID INT DEFAULT 0,
                                                            TC_NO CHAR(11) NOT NULL UNIQUE,
                                                            ADI VARCHAR(15) NOT NULL, 
                                                            SOYADI VARCHAR(15) NOT NULL,
                                                            CINSIYET CHAR,
                                                            TEL_NO CHAR(10),
                                                            DOGUM_TARIHI DATE,
                                                            EMAIL VARCHAR(25) NOT NULL UNIQUE,
                                                            LOGIN_PASSWORD VARCHAR(20) NOT NULL,
                                                            PRIMARY KEY (UYE_ID)
                                                        );";

        public static readonly string CreateUserLogin = "INSERT INTO UYELER (DANISMAN_ID, TC_NO, ADI, SOYADI, CINSIYET, TEL_NO, DOGUM_TARIHI, EMAIL, LOGIN_PASSWORD) VALUES (@DANISMAN_ID, @TC_NO, @ADI, @SOYADI, @CINSIYET, @TEL_NO, @DOGUM_TARIHI, @EMAIL, @LOGIN_PASSWORD);";
        public static readonly string UpdateUserLogin = "UPDATE UYELER SET DANISMAN_ID = @danisman_id, TC_NO = @tc_no, ADI = @adi, SOYADI = @soyadi, CINSIYET = @cinsiyet, TEL_NO = @tel_no, DOGUM_TARIHI = @dogum_tarihi, EMAIL = @email, LOGIN_PASSWORD = @login_password WHERE uye_id = @uye_id;";
        public static readonly string DeleteUser = "DELETE FROM uyeler WHERE uye_id = @uye_id";
        public static readonly string CheckUserLogin = "SELECT * FROM UYELER WHERE EMAIL = @email AND LOGIN_PASSWORD = @login_password;";

    }
}