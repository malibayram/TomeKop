CREATE EXTENSION pgcrypto;

--DROP TABLE uyeler CASCADE;
CREATE TABLE uyeler (
  UYE_ID  		 SERIAL  NOT NULL,
  TC_NO  		 CHAR(11) NOT NULL UNIQUE,
  ADI     		 VARCHAR(15) NOT NULL, 
  SOYADI 		 VARCHAR(15) NOT NULL,
  CINSIYET  	 	 CHAR,
  TEL_NO  	 	 BIGINT,
  DOGUM_TARIHI  	 DATE,
  EMAIL 		 TEXT NOT NULL UNIQUE,
  LOGIN_PASSWORD TEXT NOT NULL,
  PRIMARY KEY (UYE_ID)
);


--DROP TABLE adres CASCADE;
CREATE TABLE adres (
  uye_ID   	 	 SERIAL NOT NULL,
  ilce		     VARCHAR(15),
  il 			 VARCHAR(15),
  mahalle 		VARCHAR(15),
  adres			VARCHAR(36),
  FOREIGN KEY (uye_ID) REFERENCES uyeler(uye_ID) ON DELETE CASCADE
);


--DROP TABLE arsa CASCADE;
CREATE TABLE arsa (
  arsa_ID 	SERIAL  NOT NULL,
  parsel 	INT,
  alan_m2 	 INT,
  kullanim_tipi  VARCHAR(15),
  tapu_sahibi  	 VARCHAR(15)  NOT NULL,
  tapu_tarihi 	 DATE,
  uye_ID  	     SERIAL NOT NULL,
  PRIMARY KEY (arsa_ID),
  FOREIGN KEY (uye_ID) REFERENCES uyeler(uye_ID) ON DELETE CASCADE
);

--DROP TABLE URUN CASCADE;
CREATE TABLE URUN (
  urun_ID    		SERIAL  NOT NULL,
  urun_adi  		VARCHAR(15)  NOT NULL,
  cinsi      		CHAR(9),
  miktar_ton     		NUMERIC(10,3),
  alis_kg       		NUMERIC(10,3),
  satis_kg	 		NUMERIC(10,3),
  uret_tarihi 		DATE,
  uye_ID  			SERIAL not null,
  PRIMARY KEY (urun_ID),
  FOREIGN KEY (uye_ID) REFERENCES uyeler(uye_ID)
);
