namespace TomeKop.Utils
{
    public class SqlCommands
    {
        public static string CheckIfUyelerTableExist = "SELECT * FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'uyeler'";
        public static string CreateUyeTable = @"CREATE TABLE uyeler(
                                                    id SERIAL PRIMARY KEY,
                                                    isimsoyisim VARCHAR(55),
                                                    email VARCHAR(55),
                                                    sifre VARCHAR(20),
                                                    dogumtarihi DATE,
                                                    cinsiyet CHAR,
                                                    telefon CHAR(10),
                                                    tcno CHAR(11)
                                                )";
    }
}