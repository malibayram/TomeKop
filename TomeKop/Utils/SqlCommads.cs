namespace TomeKop.Utils
{
    public class SqlCommands
    {
        public static string CheckIfUyelerTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'uyeler'";
        public static string CreateUyeTable = @"CREATE TABLE uyeler (
                                                    UYE_ID SERIAL NOT NULL,
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

        public static string CreatekUserLogin = "INSERT INTO UYELER (TC_NO, ADI,SOYADI, CINSIYET, TEL_NO, DOGUM_TARIHI, EMAIL, LOGIN_PASSWORD) VALUES (@TC_NO, @ADI, @SOYADI, @CINSIYET, @TEL_NO, @DOGUM_TARIHI, @EMAIL, @LOGIN_PASSWORD);";
        public static string CheckUserLogin = "SELECT * FROM UYELER WHERE EMAIL = @email AND LOGIN_PASSWORD = @login_password;";

    }
}