namespace TomeKop.Utils
{
    public class SQLFuncs
    {
        public static readonly string TotalUrunC = "SELECT TOTAL_URUN(girilen_urun := @girilen_urun, yil := @yil);";
        public static readonly string MaxKarliUrunC = "SELECT max_karli_urun(yil := @yil);";
        public static readonly string MinKarliUrunC = "SELECT min_karli_urun(yil := @yil);";
        public static readonly string TotalUrun = @"create or replace function TOTAL_URUN(girilen_urun URUNLER.URUN_ADI%TYPE,YIL INT)
                                                        returns NUMERIC(10,3) as $$
                                                        declare 
                                                            toplam URUNLER.MIKTAR_TON%TYPE;
                                                            urun_miktar record;
                                                            c_urun cursor(girilen_urun URUNLER.URUN_ADI%TYPE,YIL INT) 
                                                                for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL, SUM(MIKTAR_TON) AS TOTAL_MIKTAR FROM URUNLER 
                                                                WHERE URUN_ADI=girilen_urun AND CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=YIL 
                                                                GROUP BY URUN_ADI,URET_YIL;
                                                        begin
                                                        -- open the cursor
                                                        open c_urun (girilen_urun,YIL);
                                                            
                                                        loop
                                                            -- ROW ları gez
                                                            fetch c_urun into urun_miktar;
                                                            -- son rowa kadar
                                                            exit when not found;
                                                            
                                                            --output 
                                                            toplam:= urun_miktar.TOTAL_MIKTAR;
                                                            
                                                        end loop;

                                                            return toplam;
                                                        close c_urun;

                                                        end; $$
                                                    language plpgsql;";

        public static readonly string MaxKarliUrun = @"create or replace function MAX_KARLI_URUN(YIL INT)
                                                        returns SETOF VARCHAR as $$
                                                        declare 

                                                        --RECORD
                                                            urun_KARLARI RECORD;
                                                            --CURSOR VE QUERY
                                                            c_KAR cursor(YIL INT) 
                                                                for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL,MAX(SATIS_KG-ALIS_KG) AS MAX_KAR FROM URUNLER 
                                                                WHERE CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=YIL
                                                                GROUP BY URUN_ADI,URET_YIL
                                                                ORDER BY MAX_KAR DESC
                                                                FETCH FIRST 1 ROW ONLY;
                                                        begin
                                                        -- open the cursor
                                                        open c_KAR (YIL);
                                                            
                                                        loop
                                                            -- ROW ları gez
                                                            fetch c_KAR into urun_KARLARI;
                                                            -- son rowa kadar
                                                            exit when not found;

                                                        --OUTPUT

                                                            RETURN next urun_KARLARI.URUN_ADI;

                                                        end loop;

                                                        close c_KAR;
                                                            RETURN;
                                                        end; $$ 
                                                    language plpgsql;";

        public static readonly string MinKarliUrun = @"create or replace function MIN_KARLI_URUN(YIL INT)
                                                        returns SETOF VARCHAR as $$
                                                        declare 

                                                        --RECORD
                                                            urun_KARLARI RECORD;
                                                            --CURSOR VE QUERY
                                                            c_KAR cursor(YIL INT) 
                                                                for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL,MIN(SATIS_KG-ALIS_KG) AS MIN_KAR FROM URUNLER 
                                                                WHERE CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=YIL
                                                                GROUP BY URUN_ADI,URET_YIL
                                                                ORDER BY MIN_KAR ASC
                                                                FETCH FIRST 1 ROW ONLY;
                                                        begin
                                                        -- open the cursor-- 
                                                        open c_KAR (YIL);
                                                            
                                                        loop
                                                            -- ROW ları gez--loopsuz da yazılabilir sadece baştaki rowu döndürüyor ama tek ve küçük bir tablo o yüzden genel yapıda yazıldı
                                                            fetch c_KAR into urun_KARLARI;
                                                            -- son rowa kadar
                                                            exit when not found;
                                                        
                                                        --OUTPUT
                                                        
                                                            RETURN next urun_KARLARI.URUN_ADI;

                                                        end loop;

                                                        close c_KAR;
                                                            RETURN;
                                                        end; $$ 
                                                    language plpgsql;";
    }
}