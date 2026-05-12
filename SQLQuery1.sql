-- ============================================
-- DATABASE: StudioMusik_DB (PERBAIKAN)
-- ============================================

CREATE DATABASE StudioMusik_DB;
GO
USE StudioMusik_DB;
GO

USE StudioMusik_DB;
GO

DROP TABLE IF EXISTS tbl_laporan;
DROP TABLE IF EXISTS tbl_pembayaran;
DROP TABLE IF EXISTS tbl_booking;
DROP TABLE IF EXISTS tbl_jadwal;
DROP TABLE IF EXISTS tbl_fasilitas;
DROP TABLE IF EXISTS tbl_studio;
DROP TABLE IF EXISTS tbl_admin;
DROP TABLE IF EXISTS pelanggan;
DROP TABLE IF EXISTS users;
GO

CREATE TABLE users (
    id_user    INT IDENTITY(1,1) PRIMARY KEY,
    Username   VARCHAR(50) NOT NULL UNIQUE,
    Email      VARCHAR(50) NOT NULL UNIQUE,
    Password   VARCHAR(50) NOT NULL,
    role       VARCHAR(20) NOT NULL CHECK (role IN ('admin', 'pelanggan')),
    is_active  BIT DEFAULT 1,
    created_at DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE pelanggan (
    id_pelanggan INT IDENTITY(1,1) PRIMARY KEY,
    id_user      INT NOT NULL UNIQUE,
    Nama         VARCHAR(100) NOT NULL,
    Username     VARCHAR(50),
    NoTelp       VARCHAR(15),
    Email        VARCHAR(50),
    Alamat       VARCHAR(255),
    Password     VARCHAR(50),
    FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE
);
GO

CREATE TABLE tbl_admin (
    id_admin     INT IDENTITY(1,1) PRIMARY KEY,
    id_user      INT NOT NULL UNIQUE,
    Nama         VARCHAR(100) NOT NULL,
    jabatan      VARCHAR(50),
    hak_akses    VARCHAR(50),
    NoTelp       VARCHAR(15),
    FOREIGN KEY (id_user) REFERENCES users(id_user) ON DELETE CASCADE
);
GO

CREATE TABLE tbl_studio (
    id_studio     INT IDENTITY(1,1) PRIMARY KEY,
    nama_studio   VARCHAR(50) NOT NULL,
    kapasitas     INT,
    harga_per_jam DECIMAL(10,2),
    deskripsi     TEXT,
    status        VARCHAR(20) DEFAULT 'aktif' CHECK (status IN ('aktif', 'nonaktif')),
    created_at    DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE tbl_fasilitas (
    id_fasilitas   INT IDENTITY(1,1) PRIMARY KEY,
    id_studio      INT NOT NULL,
    nama_fasilitas VARCHAR(50),
    keterangan     VARCHAR(255),
    FOREIGN KEY (id_studio) REFERENCES tbl_studio(id_studio) ON DELETE CASCADE
);
GO

CREATE TABLE tbl_jadwal (
    id_jadwal   INT IDENTITY(1,1) PRIMARY KEY,
    id_studio   INT NOT NULL,
    tanggal     DATE NOT NULL,
    jam_mulai   TIME NOT NULL,
    jam_selesai TIME NOT NULL,
    status      VARCHAR(20) DEFAULT 'tersedia' CHECK (status IN ('tersedia', 'dipesan', 'ditutup')),
    keterangan  VARCHAR(255),
    FOREIGN KEY (id_studio) REFERENCES tbl_studio(id_studio)
);
GO

CREATE TABLE tbl_booking (
    id_booking      INT IDENTITY(1,1) PRIMARY KEY,
    id_pelanggan    INT NOT NULL,
    id_jadwal       INT NOT NULL,
    tanggal_booking DATETIME DEFAULT GETDATE(),
    durasi_jam      INT NOT NULL,
    total_harga     DECIMAL(10,2),
    status          VARCHAR(20) DEFAULT 'menunggu' CHECK (status IN ('menunggu', 'disetujui', 'ditolak', 'selesai')),
    catatan         TEXT,
    created_at      DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_pelanggan) REFERENCES pelanggan(id_pelanggan),
    FOREIGN KEY (id_jadwal)    REFERENCES tbl_jadwal(id_jadwal)
);
GO

CREATE TABLE tbl_pembayaran (
    id_pembayaran     INT IDENTITY(1,1) PRIMARY KEY,
    id_booking        INT NOT NULL,
    jumlah_bayar      DECIMAL(10,2),
    jumlah_kembalian  DECIMAL(10,2),
    metode_bayar      VARCHAR(50),
    status            VARCHAR(20) DEFAULT 'menunggu' CHECK (status IN ('menunggu', 'dikonfirmasi', 'ditolak')),
    tgl_pembayaran    DATETIME DEFAULT GETDATE(),
    dikonfirmasi_oleh INT,
    catatan_admin     TEXT,
    FOREIGN KEY (id_booking)        REFERENCES tbl_booking(id_booking),
    FOREIGN KEY (dikonfirmasi_oleh) REFERENCES tbl_admin(id_admin)
);
GO

CREATE TABLE tbl_laporan (
    id_laporan       INT IDENTITY(1,1) PRIMARY KEY,
    dibuat_oleh      INT NOT NULL,
    periode_mulai    DATE,
    periode_selesai  DATE,
    total_booking    INT,
    total_pendapatan DECIMAL(10,2),
    tgl_buat         DATETIME DEFAULT GETDATE(),
    file_laporan     VARCHAR(255),
    FOREIGN KEY (dibuat_oleh) REFERENCES tbl_admin(id_admin)
);
GO

-- Insert default admin
INSERT INTO users (Username, Email, Password, role)
VALUES ('admin', 'admin@gmail.com', 'admin123', 'admin');

INSERT INTO users (Username, Email, Password, role)
VALUES ('admin2', 'admin@gmail.com', 'admin123', 'admin');

INSERT INTO tbl_admin (id_user, Nama, jabatan, hak_akses)
VALUES (1, 'Administrator', 'Admin', 'full_access');
GO

SELECT * FROM users;


SELECT name, suser_sname(owner_sid) AS owner
FROM sys.databases
WHERE name = 'StudioMusik_DB';

ALTER AUTHORIZATION ON DATABASE::StudioMusik_DB TO [FADLANNASRIZAL\FADLAN];
GO

SELECT name, suser_sname(owner_sid) AS owner
FROM sys.databases
WHERE name = 'StudioMusik_DB';

-- Cek login Windows kamu yang sebenarnya
SELECT SYSTEM_USER;
SELECT USER_NAME();

SELECT name, type_desc 
FROM sys.server_principals
WHERE type IN ('U', 'S')
ORDER BY type_desc;

USE StudioMusik_DB;
GO

ALTER AUTHORIZATION ON DATABASE::StudioMusik_DB TO [FADLANNASRIZAL\lenovo];
GO

USE StudioMusik_DB;
GO

EXEC sp_changedbowner 'sa';
GO

USE StudioMusik_DB;
GO

IF NOT EXISTS (
    SELECT * FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'dbo.sysdiagrams') 
    AND type = 'U'
)
BEGIN
    EXEC sp_creatediagram N'default', 0, NULL, NULL;
END
GO


USE StudioMusik_DB;
GO

-- Buat tabel sysdiagrams jika belum ada
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.sysdiagrams') AND type = 'U')
BEGIN
    CREATE TABLE dbo.sysdiagrams (
        name        sysname NOT NULL,
        principal_id int     NOT NULL,
        diagram_id  int     IDENTITY(1,1) NOT NULL PRIMARY KEY,
        version     int,
        definition  varbinary(max),
        CONSTRAINT UK_principal_name UNIQUE (principal_id, name)
    );

    EXEC sys.sp_addextendedproperty 
        @name = N'microsoft_database_tools_support', 
        @value = 1, 
        @level0type = N'SCHEMA', @level0name = N'dbo', 
        @level1type = N'TABLE',  @level1name = N'sysdiagrams';
END
GO


-- User admin
INSERT INTO users (Username, Email, Password, role, is_active) 
VALUES ('admin', 'admin@blackrock.com', 'admin123', 'admin', 1);

INSERT INTO users (Username, Email, Password, role, is_active) 
VALUES ('adminkedua', 'admin@gmail.com', 'admin123', 'admin', 1);

-- Data admin (ganti id_user sesuai dengan id_user yang baru dibuat)
INSERT INTO tbl_admin (id_user, Nama, jabatan, hak_akses, NoTelp) 
VALUES (1, 'Fadlan', 'Super Admin', 'full', '087833696777');


USE StudioMusik_DB;
GO

-- Langkah 1: Insert ke tabel users dulu
INSERT INTO users (Username, Email, Password, role, is_active)
VALUES ('admin_baru', 'adminbaru@blackrock.com', 'admin123', 'admin', 1);

-- Langkah 2: Insert ke tabel tbl_admin (SCOPE_IDENTITY ambil id_user yang baru dibuat)
INSERT INTO tbl_admin (id_user, Nama, jabatan, hak_akses, NoTelp)
VALUES (SCOPE_IDENTITY(), 'Nama Admin Baru', 'Admin', 'full', '08123456789');

-- Langkah 1: Insert ke tabel users dulu
INSERT INTO users (Username, Email, Password, role, is_active)
VALUES ('king', 'adminbaru@blackrock.com', 'king123', 'admin', 1);

-- Langkah 2: Insert ke tabel tbl_admin (SCOPE_IDENTITY ambil id_user yang baru dibuat)
INSERT INTO tbl_admin (id_user, Nama, jabatan, hak_akses, NoTelp)
VALUES (SCOPE_IDENTITY(), 'Nama Admin Baru', 'Admin', 'full', '08123456789');

USE StudioMusik_DB;
GO

-- Insert user admin ke tabel users
INSERT INTO users (Username, Email, Password, role, is_active)
VALUES ('admin3', 'admin3@blackrock.com', 'admin123', 'admin', 1);

-- Insert data admin ke tbl_admin
INSERT INTO tbl_admin (id_user, Nama, jabatan, hak_akses, NoTelp)
VALUES (SCOPE_IDENTITY(), 'Administrator 3', 'Admin', 'full', '08111222333');

-- Cek semua admin
SELECT u.id_user, u.Username, u.Email, u.role, a.Nama, a.jabatan, a.hak_akses
FROM users u
JOIN tbl_admin a ON u.id_user = a.id_user;

-- Pastikan dulu ada data di tabel pendukung
SELECT * FROM pelanggan      -- catat id_pelanggan yang ada
SELECT * FROM tbl_studio     -- catat id_studio yang ada
SELECT * FROM tbl_jadwal     -- catat id_jadwal yang ada

-- Setelah tahu id-nya, baru insert booking
INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, tanggal_booking, catatan)
VALUES (1, 1, 2, 200000, 'menunggu', GETDATE(), 'Test booking')

INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, tanggal_booking, catatan)
VALUES (1, 1, 1, 10000, 'menunggu', GETDATE(), 'Test booking')


INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, tanggal_booking, catatan)
VALUES (1, 1, 2, 200000, 'menunggu', GETDATE(), 'Test booking')

INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, tanggal_booking, catatan)
VALUES (1, 1, 1, 10000, 'menunggu', GETDATE(), 'Test booking')

UPDATE tbl_booking SET status = 'menunggu' WHERE id_booking = 1

-- Booking untuk studio awor (id_jadwal: 3)
INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, tanggal_booking, catatan)
VALUES (2, 3, 1, 150000, 'menunggu', GETDATE(), 'Test booking awor')

