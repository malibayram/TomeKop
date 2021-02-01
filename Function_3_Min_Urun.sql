--Herhangi bir yılda minimum karı elde eden ürünü döndüren fonksiyon
--DROP FUNCTION MIN_KARLI_URUN;
create or replace function MIN_KARLI_URUN(@YIL INT)
   returns SETOF VARCHAR as $$
declare 

--RECORD
	 urun_KARLARI RECORD;
	--CURSOR VE QUERY
	 c_KAR cursor(@YIL INT) 
		 for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL,MIN(SATIS_KG-ALIS_KG) AS MIN_KAR FROM URUN 
		 WHERE CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=@YIL
		 GROUP BY URUN_ADI,URET_YIL
		 ORDER BY MIN_KAR ASC
		 FETCH FIRST 1 ROW ONLY;
begin
   -- open the cursor-- 
   open c_KAR (@YIL);
	
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
end; 

 $$ language plpgsql;

