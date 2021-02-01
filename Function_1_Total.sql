/*Herhangi bir üründen, herhangi bir yılda toplam üretilen miktarı veren fonksiyon
ürün_id, yılı => ürün record ve ürünler cursoru olsun ve toplam miktarı*/

--DROP FUNCTION TOTAL_URUN;
create or replace function TOTAL_URUN(@girilen_urun URUN.URUN_ADI%TYPE,@YIL INT)
   returns NUMERIC(10,3) as $$
declare 
	 toplam URUN.MIKTAR_TON%TYPE;
	 urun_miktar record;
	 c_urun cursor(@girilen_urun URUN.URUN_ADI%TYPE,@YIL INT) 
		 for SELECT DISTINCT URUN_ADI,CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT) as URET_YIL, SUM(MIKTAR_TON) AS TOTAL_MIKTAR FROM URUN 
		 WHERE URUN_ADI=UPPER(@girilen_urun) AND CAST(EXTRACT(YEAR FROM URET_TARIHI) AS INT)=@YIL 
		 GROUP BY URUN_ADI,URET_YIL;
begin
   -- open the cursor
   open c_urun (@girilen_urun,@YIL);
	
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

language plpgsql;


