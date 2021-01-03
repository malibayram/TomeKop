namespace TomeKop.Utils
{
    public class SQLExcepts
    {
        public static readonly string ToplamSebze = @"SELECT URUN_ADI,TOPLAM_MIKTAR_TON FROM
                                                        (SELECT URUN_ADI, SUM(MIKTAR_TON) TOPLAM_MIKTAR_TON
                                                        FROM URUNLER
                                                        GROUP BY URUN_ADI
                                                        EXCEPT
                                                        SELECT URUN_ADI, SUM(MIKTAR_TON) TOPLAM_MIKTAR_TON
                                                        FROM URUNLER
                                                        WHERE CINSI='Meyve'
                                                    GROUP BY URUN_ADI) AS MEY;";
        public static readonly string ToplamMeyve = @"SELECT URUN_ADI,TOPLAM_MIKTAR_TON FROM
                                                        (SELECT URUN_ADI, SUM(MIKTAR_TON) TOPLAM_MIKTAR_TON
                                                        FROM URUNLER
                                                        GROUP BY URUN_ADI
                                                        EXCEPT
                                                        SELECT URUN_ADI, SUM(MIKTAR_TON) TOPLAM_MIKTAR_TON
                                                        FROM URUNLER
                                                        WHERE CINSI='Sebze'
                                                    GROUP BY URUN_ADI) AS MEY;";
    }
}