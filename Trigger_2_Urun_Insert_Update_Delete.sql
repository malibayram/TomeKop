
----TRIGGER FONKSIYONU OLUŞTURMA----
DROP FUNCTION urun_musteri_sayısı() CASCADE;

create or replace function urun_musteri_sayısı()
returns trigger as $$
declare 
    URUN_SAYISI INT;
begin
	
    select COUNT(*) AS NUM_URUN
    from URUN
    where URUN_ADI = new.URUN_ADI
	GROUP BY URUN_ADI
    into URUN_SAYISI;
	IF (select COUNT(*) AS NUM_URUN---URUN SAYISI NULL ISE KAYIT YOK YAZDIR
    from URUN
    where URUN_ADI = new.URUN_ADI
	GROUP BY URUN_ADI) IS NULL
		THEN 
		raise notice 'Müşteri ürün kaydı bulunmamaktadır.';
	else
		raise notice 'Müşteri ürün kaydı güncellenmiştir.';
    	raise notice 'İşleme alınan ürün: % - Ürün satıcı sayısı: %', new.URUN_ADI, URUN_SAYISI;
    	return new;
	end if;
end;
$$ language plpgsql;

--TRIGGER OLUŞTURMA VE FONKSIYON İLE REFERANS ETME----
create trigger urun_musteri_sayısı_trigger
AFTER insert OR UPDATE or delete on URUN
for each row
execute procedure urun_musteri_sayısı();

---KONTROLLER
select*from urun;

INSERT INTO URUN (urun_adi,cinsi,miktar_ton,alis_kg,satis_kg,uret_tarihi,uye_ID) VALUES
    ( 'ELMA','SARI',10,5,7,'2020-01-01',(SELECT UYE_ID from UYELER WHERE EMAIL='ornek@ornek.com'));

UPDATE URUN SET	URUN_ADI='ARMUT' WHERE URUN_ADI='ELMA'

DELETE FROM URUN WHERE URUN_ADI='ARMUT';
