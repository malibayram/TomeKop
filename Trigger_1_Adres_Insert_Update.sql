--ADRES TRIGGER FONKSIYONU----
DROP FUNCTION il_musteri_sayısı() CASCADE;
create or replace function il_musteri_sayısı()
returns trigger as $$
declare 
    IL_MUSTERI INT;
begin
    select COUNT(*) AS NUM_IL
    from ADRES
    where IL = new.IL
	GROUP BY IL
    into IL_MUSTERI;
	raise notice 'Müşteri adres kaydı güncellenmiştir.';
    raise notice 'Kayıtlı il: % İldeki kayıtlı kişi sayısı: %', new.IL, IL_MUSTERI;
    return new;
end;
$$ language plpgsql;

--TRIGGER VE FONKSIYON BIRLESTIRME---
create trigger il_musteri_sayısı_trigger
AFTER insert OR UPDATE on ADRES
for each row
execute procedure il_musteri_sayısı();

--ADRES TRIGGER KONTROLÜ---

INSERT INTO ADRES (IL,ILCE,MAHALLE,ADRES,UYE_ID) VALUES
    ('ANKARA','BEBEK','ORNEK MAH','ORNEK CAD ORNEK SOK ORNEK APT NO:10',(SELECT UYE_ID from UYELER WHERE EMAIL='ornek@ornek.com'));
	
	Select*from adres where Il='ANKARA';
	
UPDATE ADRES SET IL='ARTVIN' WHERE IL='ANKARA';