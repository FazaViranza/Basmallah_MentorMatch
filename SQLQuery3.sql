CREATE DATABASE MentorMatchMabarDB;
GO

USE MentorMatchMabarDB;
GO

-- ======================
-- MAHASISWA
-- ======================

CREATE TABLE Mahasiswa (

    NIM VARCHAR(15) PRIMARY KEY,

    NamaMahasiswa VARCHAR(100) NOT NULL,

    Prodi VARCHAR(50) NOT NULL,

    Email VARCHAR(100) UNIQUE

);

-- ======================
-- DOSEN
-- ======================

CREATE TABLE Dosen (

    NIDN VARCHAR(15) PRIMARY KEY,

    NamaDosen VARCHAR(100) NOT NULL,

    Jenis VARCHAR(50) NOT NULL,

    Status VARCHAR(20) 
    DEFAULT 'Available'

);

-- ======================
-- JENIS LOMBA
-- ======================

CREATE TABLE JenisLomba (

    JenisID INT 
    PRIMARY KEY IDENTITY(1,1),

    NamaJenis VARCHAR(50) NOT NULL

);

-- ======================
-- PENGAJUAN LOMBA
-- ======================

CREATE TABLE PengajuanLomba (

    PengajuanID INT 
    PRIMARY KEY IDENTITY(1,1),

    NIM VARCHAR(15) NOT NULL,

    NIDN VARCHAR(15) NOT NULL,

    JenisID INT NOT NULL,

    NamaLomba VARCHAR(100) NOT NULL,

    Penyelenggara VARCHAR(100) NOT NULL,

    TanggalPelaksanaan DATE NOT NULL,

    Status VARCHAR(20) 
    DEFAULT 'Pending',

    FOREIGN KEY (NIM)
    REFERENCES Mahasiswa(NIM),

    FOREIGN KEY (NIDN)
    REFERENCES Dosen(NIDN),

    FOREIGN KEY (JenisID)
    REFERENCES JenisLomba(JenisID)

);

-- ======================
-- USERS LOGIN
-- ======================

CREATE TABLE Users (

    UserID INT 
    PRIMARY KEY IDENTITY(1,1),

    Username VARCHAR(50),

    Password VARCHAR(50),

    Role VARCHAR(20)

);


-- dummydata
INSERT INTO Users VALUES
('admin','123','Admin'),
('mhs1','123','Mahasiswa'),
('dsn1','123','Dosen');

INSERT INTO Mahasiswa VALUES
('2311010001','Andi Pratama','Informatika','andi@mail.com'),
('2311010002','Budi Santoso','Sistem Informasi','budi@mail.com'),
('2311010003','Citra Lestari','Informatika','citra@mail.com');

INSERT INTO Dosen VALUES
('D001','Dr. Ahmad','UI/UX','Available'),
('D002','Dr. Siti','Programming','Available'),
('D003','Dr. Budi','Olahraga','Available');

INSERT INTO JenisLomba (NamaJenis) VALUES
('Programing'),
('Cyber Security'),
('UI/UX'),
('CTF');

INSERT INTO PengajuanLomba 
(NIM, NIDN, JenisID, NamaLomba, Penyelenggara, TanggalPelaksanaan, Status)
VALUES

('2311010001','D001',3,'UI/UX Competition','Universitas Indonesia','2026-06-15','Pending'),

('2311010002','D002',1,'Programming Contest','Institut Teknologi Bandung','2026-07-10','Approved'),

('2311010003','D003',4,'CTF Nasional','Universitas Gadjah Mada','2026-08-20','Rejected');

DROP TABLE PengajuanLomba;

SELECT * FROM Dosen
SELECT * FROM Mahasiswa
SELECT * FROM JenisLomba
SELECT * FROM PengajuanLomba
SELECT * FROM Users

