--Herhangi bir yılda maksimum karı elde eden ürünü döndüren fonksiyon
--DROP FUNCTION MAX_KARLI_URUN;
create or replace function MAX_KARLI_URUN(@YIL INT)
   returns SETOF VARCHAR as $$
declare 

--RECORD
	 urun_KARLARI RECORD;
	--CURSOR VE QUERY
	 c_KAR cursor(@YIL INT) 
		 for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL,MAX(SATIS_KG-ALIS_KG) AS MAX_KAR FROM URUN 
		 WHERE CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=@YIL
		 GROUP BY URUN_ADI,URET_YIL
		 ORDER BY MAX_KAR DESC
		 FETCH FIRST 1 ROW ONLY;
begin
   -- open the cursor
   open c_KAR (@YIL);
	
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
end; 

 $$ language plpgsql;




