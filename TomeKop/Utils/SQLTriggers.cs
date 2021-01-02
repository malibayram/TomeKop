namespace TomeKop.Utils
{
    public class SQLTriggers
    {
        public static readonly string CreateIlUyeSayiTrigger = @"create or replace function il_musteri_sayısı()
                                                                    returns trigger as $$
                                                                    declare 
                                                                        IL_MUSTERI INT;
                                                                    begin
                                                                        select COUNT(*) AS NUM_IL
                                                                        from ADRESLER
                                                                        where IL = new.IL
                                                                        GROUP BY IL
                                                                        into IL_MUSTERI;
                                                                        raise notice 'Müşteri adres kaydı güncellenmiştir.';
                                                                        raise notice 'Kayıtlı il: % İldeki kayıtlı kişi sayısı: %', new.IL, IL_MUSTERI;
                                                                        return new;
                                                                    end;
                                                                    $$ language plpgsql;

                                                                create trigger il_musteri_sayısı_trigger
                                                                    AFTER insert OR UPDATE on ADRESLER
                                                                    for each row
                                                                execute procedure il_musteri_sayısı();";
        public static readonly string CreateUrunUyeSayiTrigger = @"create or replace function urun_musteri_sayısı()
                                                                    returns trigger as $$
                                                                    declare 
                                                                        URUN_SAYISI INT;

                                                                    begin
                                                                        select COUNT(*) AS NUM_URUN
                                                                        from URUNLER
                                                                        where URUN_ADI = new.URUN_ADI
                                                                        GROUP BY URUN_ADI
                                                                        into URUN_SAYISI;
                                                                        IF (select COUNT(*) AS NUM_URUN ---URUN SAYISI NULL ISE KAYIT YOK YAZDIR
                                                                        from URUNLER
                                                                        where URUN_ADI = new.URUN_ADI
                                                                        GROUP BY URUN_ADI) IS NULL
                                                                            THEN 
                                                                            raise notice 'Müşteri ürün kaydı bulunmamaktadır.';
                                                                            return new;
                                                                        else
                                                                            raise notice 'Müşteri ürün kaydı güncellenmiştir.';
                                                                                raise notice 'İşleme alınan ürün: % - Ürün satıcı sayısı: %', new.URUN_ADI, URUN_SAYISI;
                                                                                return new;
                                                                        end if;
                                                                    end;
                                                                    $$ language plpgsql;

                                                                create trigger urun_musteri_sayısı_trigger
                                                                    AFTER insert OR UPDATE or delete on URUNLER
                                                                    for each row
                                                                execute procedure urun_musteri_sayısı();";
    }
}