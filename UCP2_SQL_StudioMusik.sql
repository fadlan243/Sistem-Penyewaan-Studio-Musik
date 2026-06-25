-- ============================================================
-- UCP 2 - STORED PROCEDURES, VIEWS, SQL INJECTION DEMO
-- DATABASE: StudioMusik_DB
-- ============================================================

USE StudioMusik_DB;
GO

-- ============================================================
-- ==================== V I E W S ============================
-- ============================================================

-- VIEW 1: Data lengkap studio dengan jumlah jadwal dan booking
CREATE OR ALTER VIEW vw_StudioLengkap AS
SELECT 
    s.id_studio,
    s.nama_studio,
    s.kapasitas,
    s.harga_per_jam,
    CAST(s.deskripsi AS NVARCHAR(MAX)) AS deskripsi,
    s.status,
    s.created_at,
    COUNT(DISTINCT j.id_jadwal) AS total_jadwal,
    COUNT(DISTINCT b.id_booking) AS total_booking,
    ISNULL(SUM(p.jumlah_bayar), 0) AS total_pendapatan
FROM tbl_studio s
LEFT JOIN tbl_jadwal j ON s.id_studio = j.id_studio
LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal AND b.status = 'selesai'
LEFT JOIN tbl_pembayaran p ON b.id_booking = p.id_booking AND p.status = 'dikonfirmasi'
GROUP BY s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam, 
         CAST(s.deskripsi AS NVARCHAR(MAX)), s.status, s.created_at;
GO

-- VIEW 2: Data lengkap booking + pelanggan + studio + jadwal
CREATE OR ALTER VIEW vw_BookingLengkap AS
SELECT 
    b.id_booking,
    p.id_pelanggan,
    p.Nama AS nama_pelanggan,
    p.NoTelp,
    p.Email,
    s.id_studio,
    s.nama_studio,
    s.harga_per_jam,
    j.id_jadwal,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    b.durasi_jam,
    b.total_harga,
    b.status AS status_booking,
    b.tanggal_booking,
    b.catatan,
    py.id_pembayaran,
    py.jumlah_bayar,
    py.jumlah_kembalian,
    py.metode_bayar,
    py.status AS status_pembayaran,
    py.tgl_pembayaran
FROM tbl_booking b
JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
JOIN tbl_studio s ON j.id_studio = s.id_studio
LEFT JOIN tbl_pembayaran py ON b.id_booking = py.id_booking;
GO

-- VIEW 3: Data lengkap users (pelanggan + admin)
CREATE OR ALTER VIEW vw_UserLengkap AS
SELECT 
    u.id_user,
    u.Username,
    u.Email,
    u.role,
    u.is_active,
    u.created_at,
    CASE 
        WHEN u.role = 'pelanggan' THEN p.Nama
        WHEN u.role = 'admin' THEN a.Nama
        ELSE u.Username
    END AS nama_lengkap,
    CASE 
        WHEN u.role = 'pelanggan' THEN p.NoTelp
        WHEN u.role = 'admin' THEN a.NoTelp
        ELSE '-'
    END AS no_telp,
    CASE 
        WHEN u.role = 'pelanggan' THEN p.Alamat
        ELSE '-'
    END AS alamat,
    a.jabatan,
    a.hak_akses,
    p.id_pelanggan,
    a.id_admin
FROM users u
LEFT JOIN pelanggan p ON u.id_user = p.id_user
LEFT JOIN tbl_admin a ON u.id_user = a.id_user;
GO

-- VIEW 4: Jadwal lengkap dengan info studio dan status booking
CREATE OR ALTER VIEW vw_JadwalLengkap AS
SELECT 
    j.id_jadwal,
    s.id_studio,
    s.nama_studio,
    s.harga_per_jam,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 AS DECIMAL(5,2)) AS durasi_jam,
    j.status,
    j.keterangan,
    COUNT(b.id_booking) AS jumlah_booking
FROM tbl_jadwal j
JOIN tbl_studio s ON j.id_studio = s.id_studio
LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal AND b.status NOT IN ('ditolak')
GROUP BY j.id_jadwal, s.id_studio, s.nama_studio, s.harga_per_jam,
         j.tanggal, j.jam_mulai, j.jam_selesai, j.status, j.keterangan;
GO

-- VIEW 5: Laporan pendapatan per studio per bulan
CREATE OR ALTER VIEW vw_LaporanPendapatan AS
SELECT 
    s.id_studio,
    s.nama_studio,
    YEAR(b.tanggal_booking) AS tahun,
    MONTH(b.tanggal_booking) AS bulan,
    DATENAME(MONTH, b.tanggal_booking) AS nama_bulan,
    COUNT(b.id_booking) AS jumlah_booking,
    SUM(b.durasi_jam) AS total_jam,
    SUM(p.jumlah_bayar) AS total_pendapatan
FROM tbl_booking b
JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
JOIN tbl_studio s ON j.id_studio = s.id_studio
JOIN tbl_pembayaran p ON b.id_booking = p.id_booking
WHERE b.status = 'selesai' AND p.status = 'dikonfirmasi'
GROUP BY s.id_studio, s.nama_studio, YEAR(b.tanggal_booking), 
         MONTH(b.tanggal_booking), DATENAME(MONTH, b.tanggal_booking);
GO

-- VIEW 6: Pembayaran lengkap
CREATE OR ALTER VIEW vw_PembayaranLengkap AS
SELECT 
    py.id_pembayaran,
    b.id_booking,
    p.Nama AS nama_pelanggan,
    s.nama_studio,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    b.durasi_jam,
    b.total_harga,
    py.jumlah_bayar,
    py.jumlah_kembalian,
    py.metode_bayar,
    py.status,
    py.tgl_pembayaran,
    py.catatan_admin,
    adm.Nama AS dikonfirmasi_oleh_nama
FROM tbl_pembayaran py
JOIN tbl_booking b ON py.id_booking = b.id_booking
JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
JOIN tbl_studio s ON j.id_studio = s.id_studio
LEFT JOIN tbl_admin adm ON py.dikonfirmasi_oleh = adm.id_admin;
GO


-- ============================================================
-- ============= STORED PROCEDURES ===========================
-- ============================================================

-- ==========================================
-- SP STUDIO: INSERT
-- ==========================================
CREATE OR ALTER PROCEDURE sp_InsertStudio
    @nama_studio   VARCHAR(50),
    @kapasitas     INT,
    @harga_per_jam DECIMAL(10,2),
    @deskripsi     NVARCHAR(MAX),
    @status        VARCHAR(20) = 'aktif',
    @new_id        INT OUTPUT,
    @pesan         VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi: nama studio tidak boleh duplikat
    IF EXISTS (SELECT 1 FROM tbl_studio WHERE nama_studio = @nama_studio)
    BEGIN
        SET @pesan = 'GAGAL: Nama studio sudah ada!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi: kapasitas harus positif
    IF @kapasitas <= 0
    BEGIN
        SET @pesan = 'GAGAL: Kapasitas harus lebih dari 0!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi: harga harus positif
    IF @harga_per_jam <= 0
    BEGIN
        SET @pesan = 'GAGAL: Harga per jam harus lebih dari 0!';
        SET @new_id = 0;
        RETURN;
    END

    INSERT INTO tbl_studio (nama_studio, kapasitas, harga_per_jam, deskripsi, status, created_at)
    VALUES (@nama_studio, @kapasitas, @harga_per_jam, @deskripsi, @status, GETDATE());

    SET @new_id = SCOPE_IDENTITY();
    SET @pesan = 'SUKSES: Studio "' + @nama_studio + '" berhasil ditambahkan dengan ID ' + CAST(@new_id AS VARCHAR);
END;
GO

-- ==========================================
-- SP STUDIO: UPDATE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_UpdateStudio
    @id_studio     INT,
    @nama_studio   VARCHAR(50),
    @kapasitas     INT,
    @harga_per_jam DECIMAL(10,2),
    @deskripsi     NVARCHAR(MAX),
    @status        VARCHAR(20),
    @pesan         VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi: studio harus ada
    IF NOT EXISTS (SELECT 1 FROM tbl_studio WHERE id_studio = @id_studio)
    BEGIN
        SET @pesan = 'GAGAL: Studio tidak ditemukan!';
        RETURN;
    END

    -- Validasi: nama duplikat (kecuali diri sendiri)
    IF EXISTS (SELECT 1 FROM tbl_studio WHERE nama_studio = @nama_studio AND id_studio <> @id_studio)
    BEGIN
        SET @pesan = 'GAGAL: Nama studio sudah digunakan oleh studio lain!';
        RETURN;
    END

    -- Jika nonaktifkan studio yang punya jadwal tersedia, update jadwal juga
    IF @status = 'nonaktif'
    BEGIN
        UPDATE tbl_jadwal 
        SET status = 'ditutup', keterangan = 'Studio dinonaktifkan'
        WHERE id_studio = @id_studio AND status = 'tersedia';
    END

    UPDATE tbl_studio 
    SET nama_studio   = @nama_studio,
        kapasitas     = @kapasitas,
        harga_per_jam = @harga_per_jam,
        deskripsi     = @deskripsi,
        status        = @status
    WHERE id_studio = @id_studio;

    SET @pesan = 'SUKSES: Studio berhasil diperbarui.';
END;
GO

-- ==========================================
-- SP STUDIO: DELETE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeleteStudio
    @id_studio INT,
    @pesan     VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi: studio harus ada
    IF NOT EXISTS (SELECT 1 FROM tbl_studio WHERE id_studio = @id_studio)
    BEGIN
        SET @pesan = 'GAGAL: Studio tidak ditemukan!';
        RETURN;
    END

    -- Cek apakah ada booking aktif
    DECLARE @jumlah_booking INT;
    SELECT @jumlah_booking = COUNT(*)
    FROM tbl_booking b
    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
    WHERE j.id_studio = @id_studio AND b.status IN ('menunggu', 'disetujui');

    IF @jumlah_booking > 0
    BEGIN
        SET @pesan = 'GAGAL: Studio memiliki ' + CAST(@jumlah_booking AS VARCHAR) + 
                     ' booking aktif. Selesaikan atau tolak booking terlebih dahulu!';
        RETURN;
    END

    DECLARE @nama_studio VARCHAR(50);
    SELECT @nama_studio = nama_studio FROM tbl_studio WHERE id_studio = @id_studio;

    -- Hapus fasilitas, jadwal, baru studio
    DELETE FROM tbl_fasilitas WHERE id_studio = @id_studio;
    DELETE FROM tbl_jadwal WHERE id_studio = @id_studio;
    DELETE FROM tbl_studio WHERE id_studio = @id_studio;

    SET @pesan = 'SUKSES: Studio "' + @nama_studio + '" berhasil dihapus.';
END;
GO

-- ==========================================
-- SP STUDIO: SEARCH
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchStudio
    @keyword VARCHAR(100) = '',
    @status  VARCHAR(20) = 'semua',
    @sort_by VARCHAR(30) = 'nama' -- 'nama', 'harga_asc', 'harga_desc', 'kapasitas'
AS
BEGIN
    SET NOCOUNT ON;

    -- Dynamic sort dengan IF untuk keamanan (tidak string interpolation)
    IF @sort_by = 'harga_asc'
    BEGIN
        SELECT s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam,
               CAST(s.deskripsi AS NVARCHAR(MAX)) AS deskripsi, s.status, s.created_at,
               COUNT(DISTINCT j.id_jadwal) AS total_jadwal,
               COUNT(DISTINCT CASE WHEN b.status = 'selesai' THEN b.id_booking END) AS total_booking
        FROM tbl_studio s
        LEFT JOIN tbl_jadwal j ON s.id_studio = j.id_studio
        LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal
        WHERE (s.nama_studio LIKE '%' + @keyword + '%' OR CAST(s.deskripsi AS NVARCHAR(MAX)) LIKE '%' + @keyword + '%')
          AND (@status = 'semua' OR s.status = @status)
        GROUP BY s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam, CAST(s.deskripsi AS NVARCHAR(MAX)), s.status, s.created_at
        ORDER BY s.harga_per_jam ASC;
    END
    ELSE IF @sort_by = 'harga_desc'
    BEGIN
        SELECT s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam,
               CAST(s.deskripsi AS NVARCHAR(MAX)) AS deskripsi, s.status, s.created_at,
               COUNT(DISTINCT j.id_jadwal) AS total_jadwal,
               COUNT(DISTINCT CASE WHEN b.status = 'selesai' THEN b.id_booking END) AS total_booking
        FROM tbl_studio s
        LEFT JOIN tbl_jadwal j ON s.id_studio = j.id_studio
        LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal
        WHERE (s.nama_studio LIKE '%' + @keyword + '%' OR CAST(s.deskripsi AS NVARCHAR(MAX)) LIKE '%' + @keyword + '%')
          AND (@status = 'semua' OR s.status = @status)
        GROUP BY s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam, CAST(s.deskripsi AS NVARCHAR(MAX)), s.status, s.created_at
        ORDER BY s.harga_per_jam DESC;
    END
    ELSE IF @sort_by = 'kapasitas'
    BEGIN
        SELECT s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam,
               CAST(s.deskripsi AS NVARCHAR(MAX)) AS deskripsi, s.status, s.created_at,
               COUNT(DISTINCT j.id_jadwal) AS total_jadwal,
               COUNT(DISTINCT CASE WHEN b.status = 'selesai' THEN b.id_booking END) AS total_booking
        FROM tbl_studio s
        LEFT JOIN tbl_jadwal j ON s.id_studio = j.id_studio
        LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal
        WHERE (s.nama_studio LIKE '%' + @keyword + '%' OR CAST(s.deskripsi AS NVARCHAR(MAX)) LIKE '%' + @keyword + '%')
          AND (@status = 'semua' OR s.status = @status)
        GROUP BY s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam, CAST(s.deskripsi AS NVARCHAR(MAX)), s.status, s.created_at
        ORDER BY s.kapasitas DESC;
    END
    ELSE -- default: nama
    BEGIN
        SELECT s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam,
               CAST(s.deskripsi AS NVARCHAR(MAX)) AS deskripsi, s.status, s.created_at,
               COUNT(DISTINCT j.id_jadwal) AS total_jadwal,
               COUNT(DISTINCT CASE WHEN b.status = 'selesai' THEN b.id_booking END) AS total_booking
        FROM tbl_studio s
        LEFT JOIN tbl_jadwal j ON s.id_studio = j.id_studio
        LEFT JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal
        WHERE (s.nama_studio LIKE '%' + @keyword + '%' OR CAST(s.deskripsi AS NVARCHAR(MAX)) LIKE '%' + @keyword + '%')
          AND (@status = 'semua' OR s.status = @status)
        GROUP BY s.id_studio, s.nama_studio, s.kapasitas, s.harga_per_jam, CAST(s.deskripsi AS NVARCHAR(MAX)), s.status, s.created_at
        ORDER BY s.nama_studio ASC;
    END
END;
GO

-- ==========================================
-- SP JADWAL: INSERT
-- ==========================================
CREATE OR ALTER PROCEDURE sp_InsertJadwal
    @id_studio   INT,
    @tanggal     DATE,
    @jam_mulai   TIME,
    @jam_selesai TIME,
    @keterangan  VARCHAR(255) = '',
    @new_id      INT OUTPUT,
    @pesan       VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi: studio harus aktif
    IF NOT EXISTS (SELECT 1 FROM tbl_studio WHERE id_studio = @id_studio AND status = 'aktif')
    BEGIN
        SET @pesan = 'GAGAL: Studio tidak ditemukan atau tidak aktif!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi: tanggal tidak boleh di masa lalu
    IF @tanggal < CAST(GETDATE() AS DATE)
    BEGIN
        SET @pesan = 'GAGAL: Tanggal jadwal tidak boleh di masa lalu!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi: jam mulai harus sebelum jam selesai
    IF @jam_mulai >= @jam_selesai
    BEGIN
        SET @pesan = 'GAGAL: Jam mulai harus lebih awal dari jam selesai!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi: tidak boleh bentrok jadwal
    IF EXISTS (
        SELECT 1 FROM tbl_jadwal
        WHERE id_studio = @id_studio
          AND tanggal = @tanggal
          AND status != 'ditutup'
          AND (
              (@jam_mulai >= jam_mulai AND @jam_mulai < jam_selesai) OR
              (@jam_selesai > jam_mulai AND @jam_selesai <= jam_selesai) OR
              (@jam_mulai <= jam_mulai AND @jam_selesai >= jam_selesai)
          )
    )
    BEGIN
        SET @pesan = 'GAGAL: Jadwal bentrok dengan jadwal yang sudah ada!';
        SET @new_id = 0;
        RETURN;
    END

    INSERT INTO tbl_jadwal (id_studio, tanggal, jam_mulai, jam_selesai, status, keterangan)
    VALUES (@id_studio, @tanggal, @jam_mulai, @jam_selesai, 'tersedia', @keterangan);

    SET @new_id = SCOPE_IDENTITY();
    SET @pesan = 'SUKSES: Jadwal berhasil ditambahkan dengan ID ' + CAST(@new_id AS VARCHAR);
END;
GO

-- ==========================================
-- SP JADWAL: UPDATE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_UpdateJadwal
    @id_jadwal   INT,
    @id_studio   INT,
    @tanggal     DATE,
    @jam_mulai   TIME,
    @jam_selesai TIME,
    @status      VARCHAR(20),
    @keterangan  VARCHAR(255),
    @pesan       VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal)
    BEGIN
        SET @pesan = 'GAGAL: Jadwal tidak ditemukan!';
        RETURN;
    END

    -- Jika jadwal sudah dipesan, tidak bisa ubah waktu
    IF EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal AND status = 'dipesan')
    BEGIN
        -- Hanya boleh update keterangan dan status saja
        UPDATE tbl_jadwal SET status = @status, keterangan = @keterangan WHERE id_jadwal = @id_jadwal;
        SET @pesan = 'PERHATIAN: Jadwal sudah dipesan. Hanya status dan keterangan yang diperbarui.';
        RETURN;
    END

    IF @jam_mulai >= @jam_selesai
    BEGIN
        SET @pesan = 'GAGAL: Jam mulai harus lebih awal dari jam selesai!';
        RETURN;
    END

    UPDATE tbl_jadwal
    SET id_studio   = @id_studio,
        tanggal     = @tanggal,
        jam_mulai   = @jam_mulai,
        jam_selesai = @jam_selesai,
        status      = @status,
        keterangan  = @keterangan
    WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Jadwal berhasil diperbarui.';
END;
GO

-- ==========================================
-- SP JADWAL: DELETE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeleteJadwal
    @id_jadwal INT,
    @pesan     VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal)
    BEGIN
        SET @pesan = 'GAGAL: Jadwal tidak ditemukan!';
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM tbl_booking WHERE id_jadwal = @id_jadwal AND status IN ('menunggu','disetujui'))
    BEGIN
        SET @pesan = 'GAGAL: Jadwal memiliki booking aktif yang belum selesai!';
        RETURN;
    END

    DELETE FROM tbl_booking WHERE id_jadwal = @id_jadwal;
    DELETE FROM tbl_jadwal WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Jadwal berhasil dihapus.';
END;
GO

-- ==========================================
-- SP JADWAL: SEARCH
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchJadwal
    @id_studio INT = 0,
    @tanggal   DATE = NULL,
    @status    VARCHAR(20) = 'semua'
AS
BEGIN
    SET NOCOUNT ON;

    SELECT j.id_jadwal, s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai,
           j.status, j.keterangan,
           CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 AS DECIMAL(5,2)) AS durasi_jam,
           s.harga_per_jam,
           CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 * s.harga_per_jam AS DECIMAL(10,2)) AS estimasi_harga
    FROM tbl_jadwal j
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE (@id_studio = 0 OR j.id_studio = @id_studio)
      AND (@tanggal IS NULL OR j.tanggal = @tanggal)
      AND (@status = 'semua' OR j.status = @status)
    ORDER BY j.tanggal DESC, j.jam_mulai;
END;
GO

-- ==========================================
-- SP BOOKING: INSERT
-- ==========================================
CREATE OR ALTER PROCEDURE sp_InsertBooking
    @id_pelanggan INT,
    @id_jadwal    INT,
    @durasi_jam   INT,
    @catatan      NVARCHAR(MAX),
    @new_id       INT OUTPUT,
    @pesan        VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi pelanggan aktif
    IF NOT EXISTS (SELECT 1 FROM pelanggan WHERE id_pelanggan = @id_pelanggan)
    BEGIN
        SET @pesan = 'GAGAL: Pelanggan tidak ditemukan!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi jadwal tersedia
    IF NOT EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal AND status = 'tersedia')
    BEGIN
        SET @pesan = 'GAGAL: Jadwal tidak tersedia atau sudah dipesan!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi durasi
    IF @durasi_jam <= 0
    BEGIN
        SET @pesan = 'GAGAL: Durasi harus lebih dari 0 jam!';
        SET @new_id = 0;
        RETURN;
    END

    -- Hitung total harga otomatis
    DECLARE @harga_per_jam DECIMAL(10,2);
    SELECT @harga_per_jam = s.harga_per_jam
    FROM tbl_jadwal j
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE j.id_jadwal = @id_jadwal;

    DECLARE @total_harga DECIMAL(10,2);
    SET @total_harga = @durasi_jam * @harga_per_jam;

    -- Insert booking
    INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, catatan, tanggal_booking, created_at)
    VALUES (@id_pelanggan, @id_jadwal, @durasi_jam, @total_harga, 'menunggu', @catatan, GETDATE(), GETDATE());

    SET @new_id = SCOPE_IDENTITY();

    -- Update status jadwal menjadi 'dipesan'
    UPDATE tbl_jadwal SET status = 'dipesan' WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Booking berhasil dibuat! Total harga: Rp ' + FORMAT(@total_harga, 'N0') + '. Menunggu konfirmasi admin.';
END;
GO

-- ==========================================
-- SP BOOKING: UPDATE STATUS
-- ==========================================
CREATE OR ALTER PROCEDURE sp_UpdateStatusBooking
    @id_booking INT,
    @status     VARCHAR(20), -- 'disetujui', 'ditolak', 'selesai'
    @id_admin   INT,
    @pesan      VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_booking WHERE id_booking = @id_booking)
    BEGIN
        SET @pesan = 'GAGAL: Booking tidak ditemukan!';
        RETURN;
    END

    DECLARE @status_lama VARCHAR(20);
    DECLARE @id_jadwal INT;
    SELECT @status_lama = status, @id_jadwal = id_jadwal FROM tbl_booking WHERE id_booking = @id_booking;

    -- Validasi transisi status
    IF @status_lama = 'selesai'
    BEGIN
        SET @pesan = 'GAGAL: Booking yang sudah selesai tidak dapat diubah!';
        RETURN;
    END

    UPDATE tbl_booking SET status = @status WHERE id_booking = @id_booking;

    -- Jika ditolak, kembalikan jadwal ke 'tersedia'
    IF @status = 'ditolak'
        UPDATE tbl_jadwal SET status = 'tersedia' WHERE id_jadwal = @id_jadwal;

    -- Jika selesai, update jadwal ke 'ditutup'
    IF @status = 'selesai'
        UPDATE tbl_jadwal SET status = 'ditutup' WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Status booking berhasil diubah menjadi "' + @status + '".';
END;
GO

-- ==========================================
-- SP BOOKING: DELETE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeleteBooking
    @id_booking INT,
    @pesan      VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_booking WHERE id_booking = @id_booking)
    BEGIN
        SET @pesan = 'GAGAL: Booking tidak ditemukan!';
        RETURN;
    END

    DECLARE @status VARCHAR(20), @id_jadwal INT;
    SELECT @status = status, @id_jadwal = id_jadwal FROM tbl_booking WHERE id_booking = @id_booking;

    IF @status = 'disetujui'
    BEGIN
        SET @pesan = 'GAGAL: Booking yang sudah disetujui tidak dapat dihapus. Tolak terlebih dahulu!';
        RETURN;
    END

    -- Kembalikan status jadwal jika booking aktif
    IF @status = 'menunggu'
        UPDATE tbl_jadwal SET status = 'tersedia' WHERE id_jadwal = @id_jadwal;

    DELETE FROM tbl_pembayaran WHERE id_booking = @id_booking;
    DELETE FROM tbl_booking WHERE id_booking = @id_booking;

    SET @pesan = 'SUKSES: Booking berhasil dihapus.';
END;
GO

-- ==========================================
-- SP BOOKING: SEARCH
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchBooking
    @id_pelanggan INT = 0,
    @status       VARCHAR(20) = 'semua',
    @tgl_mulai    DATE = NULL,
    @tgl_selesai  DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.id_booking,
        p.Nama AS nama_pelanggan,
        s.nama_studio,
        j.tanggal,
        j.jam_mulai,
        j.jam_selesai,
        b.durasi_jam,
        b.total_harga,
        b.status,
        b.catatan,
        b.tanggal_booking,
        py.status AS status_pembayaran
    FROM tbl_booking b
    JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    LEFT JOIN tbl_pembayaran py ON b.id_booking = py.id_booking
    WHERE (@id_pelanggan = 0 OR b.id_pelanggan = @id_pelanggan)
      AND (@status = 'semua' OR b.status = @status)
      AND (@tgl_mulai IS NULL OR j.tanggal >= @tgl_mulai)
      AND (@tgl_selesai IS NULL OR j.tanggal <= @tgl_selesai)
    ORDER BY b.tanggal_booking DESC;
END;
GO

-- ==========================================
-- SP PEMBAYARAN: INSERT
-- ==========================================
CREATE OR ALTER PROCEDURE sp_InsertPembayaran
    @id_booking   INT,
    @jumlah_bayar DECIMAL(10,2),
    @metode_bayar VARCHAR(50),
    @new_id       INT OUTPUT,
    @pesan        VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi booking ada dan disetujui
    IF NOT EXISTS (SELECT 1 FROM tbl_booking WHERE id_booking = @id_booking AND status = 'disetujui')
    BEGIN
        SET @pesan = 'GAGAL: Booking tidak ditemukan atau belum disetujui!';
        SET @new_id = 0;
        RETURN;
    END

    -- Cek sudah ada pembayaran
    IF EXISTS (SELECT 1 FROM tbl_pembayaran WHERE id_booking = @id_booking AND status = 'dikonfirmasi')
    BEGIN
        SET @pesan = 'GAGAL: Pembayaran untuk booking ini sudah dikonfirmasi!';
        SET @new_id = 0;
        RETURN;
    END

    DECLARE @total_harga DECIMAL(10,2);
    SELECT @total_harga = total_harga FROM tbl_booking WHERE id_booking = @id_booking;

    IF @jumlah_bayar < @total_harga
    BEGIN
        SET @pesan = 'GAGAL: Jumlah bayar kurang! Kurang Rp ' + FORMAT(@total_harga - @jumlah_bayar, 'N0');
        SET @new_id = 0;
        RETURN;
    END

    DECLARE @kembalian DECIMAL(10,2);
    SET @kembalian = @jumlah_bayar - @total_harga;

    INSERT INTO tbl_pembayaran (id_booking, jumlah_bayar, jumlah_kembalian, metode_bayar, status, tgl_pembayaran)
    VALUES (@id_booking, @jumlah_bayar, @kembalian, @metode_bayar, 'menunggu', GETDATE());

    SET @new_id = SCOPE_IDENTITY();
    SET @pesan = 'SUKSES: Pembayaran dicatat. Kembalian: Rp ' + FORMAT(@kembalian, 'N0') + '. Menunggu konfirmasi admin.';
END;
GO

-- ==========================================
-- SP PEMBAYARAN: KONFIRMASI / UPDATE STATUS
-- ==========================================
CREATE OR ALTER PROCEDURE sp_KonfirmasiPembayaran
    @id_pembayaran INT,
    @status        VARCHAR(20), -- 'dikonfirmasi' atau 'ditolak'
    @catatan_admin NVARCHAR(MAX),
    @id_admin      INT,
    @pesan         VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_pembayaran WHERE id_pembayaran = @id_pembayaran)
    BEGIN
        SET @pesan = 'GAGAL: Data pembayaran tidak ditemukan!';
        RETURN;
    END

    DECLARE @id_booking INT;
    SELECT @id_booking = id_booking FROM tbl_pembayaran WHERE id_pembayaran = @id_pembayaran;

    UPDATE tbl_pembayaran
    SET status           = @status,
        catatan_admin    = @catatan_admin,
        dikonfirmasi_oleh = @id_admin,
        tgl_pembayaran   = GETDATE()
    WHERE id_pembayaran = @id_pembayaran;

    -- Jika dikonfirmasi, update booking menjadi selesai
    IF @status = 'dikonfirmasi'
    BEGIN
        UPDATE tbl_booking SET status = 'selesai' WHERE id_booking = @id_booking;
        DECLARE @id_jadwal INT;
        SELECT @id_jadwal = id_jadwal FROM tbl_booking WHERE id_booking = @id_booking;
        UPDATE tbl_jadwal SET status = 'ditutup' WHERE id_jadwal = @id_jadwal;
    END

    SET @pesan = 'SUKSES: Pembayaran berhasil ' + 
                 CASE WHEN @status = 'dikonfirmasi' THEN 'dikonfirmasi!' ELSE 'ditolak.' END;
END;
GO

-- ==========================================
-- SP PEMBAYARAN: DELETE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeletePembayaran
    @id_pembayaran INT,
    @pesan         VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_pembayaran WHERE id_pembayaran = @id_pembayaran)
    BEGIN
        SET @pesan = 'GAGAL: Data pembayaran tidak ditemukan!';
        RETURN;
    END

    DECLARE @status VARCHAR(20);
    SELECT @status = status FROM tbl_pembayaran WHERE id_pembayaran = @id_pembayaran;

    IF @status = 'dikonfirmasi'
    BEGIN
        SET @pesan = 'GAGAL: Pembayaran yang sudah dikonfirmasi tidak dapat dihapus!';
        RETURN;
    END

    DELETE FROM tbl_pembayaran WHERE id_pembayaran = @id_pembayaran;
    SET @pesan = 'SUKSES: Data pembayaran berhasil dihapus.';
END;
GO

-- ==========================================
-- SP PEMBAYARAN: SEARCH
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchPembayaran
    @id_pelanggan  INT = 0,
    @status        VARCHAR(20) = 'semua',
    @metode_bayar  VARCHAR(50) = 'semua',
    @tgl_mulai     DATE = NULL,
    @tgl_selesai   DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        py.id_pembayaran,
        b.id_booking,
        p.Nama AS nama_pelanggan,
        s.nama_studio,
        j.tanggal,
        b.total_harga,
        py.jumlah_bayar,
        py.jumlah_kembalian,
        py.metode_bayar,
        py.status,
        py.tgl_pembayaran,
        py.catatan_admin,
        adm.Nama AS dikonfirmasi_oleh
    FROM tbl_pembayaran py
    JOIN tbl_booking b ON py.id_booking = b.id_booking
    JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    LEFT JOIN tbl_admin adm ON py.dikonfirmasi_oleh = adm.id_admin
    WHERE (@id_pelanggan = 0 OR b.id_pelanggan = @id_pelanggan)
      AND (@status = 'semua' OR py.status = @status)
      AND (@metode_bayar = 'semua' OR py.metode_bayar = @metode_bayar)
      AND (@tgl_mulai IS NULL OR py.tgl_pembayaran >= @tgl_mulai)
      AND (@tgl_selesai IS NULL OR py.tgl_pembayaran <= @tgl_selesai)
    ORDER BY py.tgl_pembayaran DESC;
END;
GO

-- ==========================================
-- SP PELANGGAN: INSERT (Register)
-- ==========================================
CREATE OR ALTER PROCEDURE sp_RegisterPelanggan
    @username  VARCHAR(50),
    @email     VARCHAR(50),
    @password  VARCHAR(50),
    @nama      VARCHAR(100),
    @notelp    VARCHAR(15),
    @alamat    VARCHAR(255),
    @new_id    INT OUTPUT,
    @pesan     VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM users WHERE Username = @username)
    BEGIN
        SET @pesan = 'GAGAL: Username sudah digunakan!';
        SET @new_id = 0;
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM users WHERE Email = @email)
    BEGIN
        SET @pesan = 'GAGAL: Email sudah terdaftar!';
        SET @new_id = 0;
        RETURN;
    END

    IF LEN(@password) < 6
    BEGIN
        SET @pesan = 'GAGAL: Password minimal 6 karakter!';
        SET @new_id = 0;
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO users (Username, Email, Password, role, is_active, created_at)
        VALUES (@username, @email, @password, 'pelanggan', 1, GETDATE());

        DECLARE @id_user INT = SCOPE_IDENTITY();

        INSERT INTO pelanggan (id_user, Nama, Username, NoTelp, Email, Alamat, Password)
        VALUES (@id_user, @nama, @username, @notelp, @email, @alamat, @password);

        SET @new_id = SCOPE_IDENTITY();
        COMMIT TRANSACTION;
        SET @pesan = 'SUKSES: Akun pelanggan "' + @username + '" berhasil didaftarkan!';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @new_id = 0;
        SET @pesan = 'GAGAL: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- ==========================================
-- SP PELANGGAN: UPDATE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_UpdatePelanggan
    @id_pelanggan INT,
    @nama         VARCHAR(100),
    @notelp       VARCHAR(15),
    @email        VARCHAR(50),
    @alamat       VARCHAR(255),
    @pesan        VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM pelanggan WHERE id_pelanggan = @id_pelanggan)
    BEGIN
        SET @pesan = 'GAGAL: Pelanggan tidak ditemukan!';
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @id_user INT;
        SELECT @id_user = id_user FROM pelanggan WHERE id_pelanggan = @id_pelanggan;

        UPDATE pelanggan
        SET Nama = @nama, NoTelp = @notelp, Email = @email, Alamat = @alamat
        WHERE id_pelanggan = @id_pelanggan;

        UPDATE users SET Email = @email WHERE id_user = @id_user;

        COMMIT TRANSACTION;
        SET @pesan = 'SUKSES: Data pelanggan berhasil diperbarui.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @pesan = 'GAGAL: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- ==========================================
-- SP PELANGGAN: DELETE
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeletePelanggan
    @id_user INT,
    @pesan   VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM users WHERE id_user = @id_user)
    BEGIN
        SET @pesan = 'GAGAL: User tidak ditemukan!';
        RETURN;
    END

    -- Cek booking aktif
    DECLARE @booking_aktif INT;
    SELECT @booking_aktif = COUNT(*) 
    FROM tbl_booking b
    JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
    WHERE p.id_user = @id_user AND b.status IN ('menunggu','disetujui');

    IF @booking_aktif > 0
    BEGIN
        SET @pesan = 'GAGAL: Pelanggan memiliki ' + CAST(@booking_aktif AS VARCHAR) + ' booking aktif!';
        RETURN;
    END

    -- ON DELETE CASCADE akan menghapus pelanggan otomatis saat user dihapus
    DELETE FROM users WHERE id_user = @id_user;
    SET @pesan = 'SUKSES: Data user dan pelanggan terkait berhasil dihapus.';
END;
GO

-- ==========================================
-- SP PELANGGAN: SEARCH
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchPelanggan
    @keyword VARCHAR(100) = '',
    @role     VARCHAR(20) = 'semua',
    @is_active BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.id_user,
        u.Username,
        u.Email,
        u.role,
        u.is_active,
        u.created_at,
        COALESCE(p.Nama, a.Nama) AS nama_lengkap,
        COALESCE(p.NoTelp, a.NoTelp) AS no_telp,
        p.Alamat,
        a.jabatan,
        p.id_pelanggan,
        a.id_admin,
        (SELECT COUNT(*) FROM tbl_booking bk WHERE bk.id_pelanggan = p.id_pelanggan) AS total_booking
    FROM users u
    LEFT JOIN pelanggan p ON u.id_user = p.id_user
    LEFT JOIN tbl_admin a ON u.id_user = a.id_user
    WHERE (u.Username LIKE '%' + @keyword + '%' 
           OR u.Email LIKE '%' + @keyword + '%'
           OR p.Nama LIKE '%' + @keyword + '%'
           OR a.Nama LIKE '%' + @keyword + '%')
      AND (@role = 'semua' OR u.role = @role)
      AND (@is_active IS NULL OR u.is_active = @is_active)
    ORDER BY u.created_at DESC;
END;
GO


-- ============================================================
-- ===== SQL INJECTION DEMO (VULNERABLE) ======================
-- Untuk keperluan edukasi UCP 2 - Form Login Rentan
-- ============================================================

-- SP rentan SQL Injection (SENGAJA DIBUAT VULNERABLE UNTUK DEMO)
CREATE OR ALTER PROCEDURE sp_LoginVulnerable
    @username VARCHAR(100),
    @password VARCHAR(100),
    @role     VARCHAR(20)
AS
BEGIN
    -- ⚠️ VULNERABLE: menggunakan dynamic SQL tanpa sanitasi
    DECLARE @sql NVARCHAR(500);
    SET @sql = 'SELECT * FROM users WHERE Username = ''' + @username + 
               ''' AND Password = ''' + @password + 
               ''' AND role = ''' + @role + '''';
    EXEC sp_executesql @sql;
END;
GO

-- SP AMAN menggunakan parameterized query (PERBAIKAN)
CREATE OR ALTER PROCEDURE sp_LoginSecure
    @username VARCHAR(100),
    @password VARCHAR(100),
    @role     VARCHAR(20)
AS
BEGIN
    -- ✅ AMAN: menggunakan parameter
    SELECT u.id_user, u.Username, u.role,
           p.id_pelanggan, p.Nama AS nama_pelanggan,
           a.id_admin, a.Nama AS nama_admin
    FROM users u
    LEFT JOIN pelanggan p ON u.id_user = p.id_user
    LEFT JOIN tbl_admin a ON u.id_user = a.id_user
    WHERE u.Username = @username
      AND u.Password = @password
      AND u.role = @role
      AND u.is_active = 1;
END;
GO

CREATE PROCEDURE sp_SearchStudio
    @keyword NVARCHAR(100) = NULL,
    @status VARCHAR(20) = 'semua',
    @sort_by VARCHAR(20) = 'nama'
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        s.id_studio,
        s.nama_studio,
        s.kapasitas,
        s.harga_per_jam,
        s.status,
        s.deskripsi,
        s.created_at,
        (SELECT COUNT(*) FROM tbl_jadwal WHERE id_studio = s.id_studio) AS total_jadwal,
        (SELECT COUNT(*) FROM tbl_jadwal j 
         JOIN tbl_booking b ON j.id_jadwal = b.id_jadwal 
         WHERE j.id_studio = s.id_studio) AS total_booking
    FROM tbl_studio s
    WHERE (@keyword IS NULL OR s.nama_studio LIKE '%' + @keyword + '%')
      AND (@status = 'semua' OR s.status = @status)
    ORDER BY 
        CASE WHEN @sort_by = 'nama' THEN s.nama_studio END ASC,
        CASE WHEN @sort_by = 'harga' THEN s.harga_per_jam END ASC,
        s.id_studio ASC
END
GO



PRINT 'Semua Stored Procedure dan View berhasil dibuat!';
GO

USE StudioMusik_DB;
SELECT * FROM tbl_studio;

EXEC sp_SearchStudio @keyword = '', @status = 'semua', @sort_by = 'nama';



=================================================================================================================
=================================================================================================================
formkelolajadwal
=================================================================================================================
=================================================================================================================

USE StudioMusik_DB;
GO

-- ==========================================
-- VIEW untuk Jadwal Lengkap
-- ==========================================
CREATE OR ALTER VIEW vw_JadwalLengkap
AS
SELECT 
    j.id_jadwal,
    s.id_studio,
    s.nama_studio,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 AS DECIMAL(5,2)) AS durasi_jam,
    j.status,
    j.keterangan,
    s.harga_per_jam,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 * s.harga_per_jam AS DECIMAL(10,2)) AS estimasi_harga,
    CASE 
        WHEN EXISTS (SELECT 1 FROM tbl_booking b WHERE b.id_jadwal = j.id_jadwal AND b.status IN ('menunggu', 'disetujui'))
        THEN 'Ada Booking Aktif'
        ELSE '-'
    END AS status_booking
FROM tbl_jadwal j
JOIN tbl_studio s ON j.id_studio = s.id_studio;
GO

-- ==========================================
-- SP INSERT JADWAL
-- ==========================================
CREATE OR ALTER PROCEDURE sp_InsertJadwal
    @id_studio   INT,
    @tanggal     DATE,
    @jam_mulai   TIME,
    @jam_selesai TIME,
    @keterangan  VARCHAR(255) = '',
    @new_id      INT OUTPUT,
    @pesan       VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi 1: Studio harus aktif
    IF NOT EXISTS (SELECT 1 FROM tbl_studio WHERE id_studio = @id_studio AND status = 'aktif')
    BEGIN
        SET @pesan = 'GAGAL: Studio tidak ditemukan atau tidak aktif!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi 2: Tanggal tidak boleh di masa lalu
    IF @tanggal < CAST(GETDATE() AS DATE)
    BEGIN
        SET @pesan = 'GAGAL: Tanggal jadwal tidak boleh di masa lalu!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi 3: Jam mulai harus sebelum jam selesai
    IF @jam_mulai >= @jam_selesai
    BEGIN
        SET @pesan = 'GAGAL: Jam mulai harus lebih awal dari jam selesai!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi 4: Minimal durasi 1 jam
    IF DATEDIFF(MINUTE, @jam_mulai, @jam_selesai) < 60
    BEGIN
        SET @pesan = 'GAGAL: Minimal durasi jadwal adalah 1 jam!';
        SET @new_id = 0;
        RETURN;
    END

    -- Validasi 5: Tidak boleh bentrok dengan jadwal existing
    IF EXISTS (
        SELECT 1 FROM tbl_jadwal
        WHERE id_studio = @id_studio
          AND tanggal = @tanggal
          AND status != 'ditutup'
          AND (
              (@jam_mulai >= jam_mulai AND @jam_mulai < jam_selesai) OR
              (@jam_selesai > jam_mulai AND @jam_selesai <= jam_selesai) OR
              (@jam_mulai <= jam_mulai AND @jam_selesai >= jam_selesai)
          )
    )
    BEGIN
        SET @pesan = 'GAGAL: Jadwal bentrok dengan jadwal yang sudah ada!';
        SET @new_id = 0;
        RETURN;
    END

    INSERT INTO tbl_jadwal (id_studio, tanggal, jam_mulai, jam_selesai, status, keterangan)
    VALUES (@id_studio, @tanggal, @jam_mulai, @jam_selesai, 'tersedia', @keterangan);

    SET @new_id = SCOPE_IDENTITY();
    SET @pesan = 'SUKSES: Jadwal berhasil ditambahkan untuk studio ID ' + CAST(@id_studio AS VARCHAR);
END;
GO

-- ==========================================
-- SP UPDATE JADWAL
-- ==========================================
CREATE OR ALTER PROCEDURE sp_UpdateJadwal
    @id_jadwal   INT,
    @id_studio   INT,
    @tanggal     DATE,
    @jam_mulai   TIME,
    @jam_selesai TIME,
    @status      VARCHAR(20),
    @keterangan  VARCHAR(255),
    @pesan       VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi: Jadwal harus ada
    IF NOT EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal)
    BEGIN
        SET @pesan = 'GAGAL: Jadwal tidak ditemukan!';
        RETURN;
    END

    -- Jika jadwal sudah dipesan, hanya bisa update keterangan dan status
    IF EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal AND status = 'dipesan')
    BEGIN
        UPDATE tbl_jadwal 
        SET status = @status, keterangan = @keterangan 
        WHERE id_jadwal = @id_jadwal;
        
        SET @pesan = 'PERHATIAN: Jadwal sudah dipesan. Hanya status dan keterangan yang diperbarui.';
        RETURN;
    END

    -- Validasi jam
    IF @jam_mulai >= @jam_selesai
    BEGIN
        SET @pesan = 'GAGAL: Jam mulai harus lebih awal dari jam selesai!';
        RETURN;
    END

    -- Validasi durasi minimal 1 jam
    IF DATEDIFF(MINUTE, @jam_mulai, @jam_selesai) < 60
    BEGIN
        SET @pesan = 'GAGAL: Minimal durasi jadwal adalah 1 jam!';
        RETURN;
    END

    -- Validasi bentrok (kecuali dengan dirinya sendiri)
    IF EXISTS (
        SELECT 1 FROM tbl_jadwal
        WHERE id_studio = @id_studio
          AND id_jadwal != @id_jadwal
          AND tanggal = @tanggal
          AND status != 'ditutup'
          AND (
              (@jam_mulai >= jam_mulai AND @jam_mulai < jam_selesai) OR
              (@jam_selesai > jam_mulai AND @jam_selesai <= jam_selesai) OR
              (@jam_mulai <= jam_mulai AND @jam_selesai >= jam_selesai)
          )
    )
    BEGIN
        SET @pesan = 'GAGAL: Jadwal bentrok dengan jadwal lain!';
        RETURN;
    END

    UPDATE tbl_jadwal
    SET id_studio   = @id_studio,
        tanggal     = @tanggal,
        jam_mulai   = @jam_mulai,
        jam_selesai = @jam_selesai,
        status      = @status,
        keterangan  = @keterangan
    WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Jadwal berhasil diperbarui!';
END;
GO

-- ==========================================
-- SP DELETE JADWAL
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DeleteJadwal
    @id_jadwal INT,
    @pesan     VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM tbl_jadwal WHERE id_jadwal = @id_jadwal)
    BEGIN
        SET @pesan = 'GAGAL: Jadwal tidak ditemukan!';
        RETURN;
    END

    -- Cek apakah ada booking aktif
    IF EXISTS (SELECT 1 FROM tbl_booking WHERE id_jadwal = @id_jadwal AND status IN ('menunggu', 'disetujui'))
    BEGIN
        SET @pesan = 'GAGAL: Jadwal memiliki booking aktif yang belum selesai!';
        RETURN;
    END

    DELETE FROM tbl_booking WHERE id_jadwal = @id_jadwal;
    DELETE FROM tbl_jadwal WHERE id_jadwal = @id_jadwal;

    SET @pesan = 'SUKSES: Jadwal berhasil dihapus!';
END;
GO

-- ==========================================
-- SP SEARCH JADWAL
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchJadwal
    @id_studio INT = 0,
    @tanggal   DATE = NULL,
    @status    VARCHAR(20) = 'semua'
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM vw_JadwalLengkap
    WHERE (@id_studio = 0 OR id_studio = @id_studio)
      AND (@tanggal IS NULL OR tanggal = @tanggal)
      AND (@status = 'semua' OR status = @status)
    ORDER BY tanggal DESC, jam_mulai;
END;
GO

PRINT 'Stored Procedure dan View untuk FormKelolaJadwal berhasil dibuat!';
GO


===============================================================================
===============================================================================
formbookingstudio
===============================================================================
===============================================================================
USE StudioMusik_DB;
GO

-- ==========================================
-- VIEW: Jadwal yang Tersedia untuk Booking (TANPA ORDER BY)
-- ==========================================
CREATE OR ALTER VIEW vw_JadwalTersedia
AS
SELECT 
    j.id_jadwal,
    s.id_studio,
    s.nama_studio,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 AS DECIMAL(5,2)) AS durasi_jam,
    s.harga_per_jam,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 * s.harga_per_jam AS DECIMAL(10,2)) AS estimasi_harga,
    j.status,
    s.kapasitas,
    s.deskripsi
FROM tbl_jadwal j
JOIN tbl_studio s ON j.id_studio = s.id_studio
WHERE j.status = 'tersedia' 
  AND j.tanggal >= CAST(GETDATE() AS DATE);
GO

-- ==========================================
-- VIEW: Riwayat Booking untuk Pelanggan (TANPA ORDER BY)
-- ==========================================
CREATE OR ALTER VIEW vw_RiwayatBookingPelanggan
AS
SELECT 
    b.id_booking,
    b.id_pelanggan,
    p.Nama AS nama_pelanggan,
    s.nama_studio,
    j.tanggal,
    j.jam_mulai,
    j.jam_selesai,
    b.durasi_jam,
    b.total_harga,
    b.status,
    b.tanggal_booking,
    b.catatan,
    py.status AS status_pembayaran,
    py.jumlah_bayar,
    py.metode_bayar,
    py.tgl_pembayaran
FROM tbl_booking b
JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
JOIN tbl_studio s ON j.id_studio = s.id_studio
LEFT JOIN tbl_pembayaran py ON b.id_booking = py.id_booking;
GO

-- ==========================================
-- SP: Search Jadwal Tersedia (ORDER BY boleh di SP)
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchJadwalTersedia
    @id_studio INT = 0,
    @tanggal   DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM vw_JadwalTersedia
    WHERE (@id_studio = 0 OR id_studio = @id_studio)
      AND (@tanggal IS NULL OR tanggal = @tanggal)
    ORDER BY tanggal ASC, jam_mulai ASC;  -- ✅ ORDER BY di SP, bukan di VIEW
END;
GO

-- ==========================================
-- SP: Search Riwayat Booking untuk Pelanggan
-- ==========================================
CREATE OR ALTER PROCEDURE sp_SearchRiwayatBooking
    @id_pelanggan INT,
    @status       VARCHAR(20) = 'semua'
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM vw_RiwayatBookingPelanggan
    WHERE id_pelanggan = @id_pelanggan
      AND (@status = 'semua' OR status = @status)
    ORDER BY tanggal_booking DESC;  -- ✅ ORDER BY di SP
END;
GO

-- ==========================================
-- SP: Cancel Booking (Batalkan oleh Pelanggan)
-- ==========================================
CREATE OR ALTER PROCEDURE sp_CancelBooking
    @id_booking INT,
    @id_pelanggan INT,
    @pesan       VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validasi booking milik pelanggan
    IF NOT EXISTS (SELECT 1 FROM tbl_booking WHERE id_booking = @id_booking AND id_pelanggan = @id_pelanggan)
    BEGIN
        SET @pesan = 'GAGAL: Booking tidak ditemukan!';
        RETURN;
    END

    -- Cek status booking (hanya bisa cancel jika status 'menunggu')
    DECLARE @status VARCHAR(20);
    SELECT @status = status FROM tbl_booking WHERE id_booking = @id_booking;
    
    IF @status != 'menunggu'
    BEGIN
        SET @pesan = 'GAGAL: Booking tidak dapat dibatalkan karena status sudah ' + @status + '!';
        RETURN;
    END

    DECLARE @id_jadwal INT;
    SELECT @id_jadwal = id_jadwal FROM tbl_booking WHERE id_booking = @id_booking;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Update status booking menjadi 'ditolak'
        UPDATE tbl_booking SET status = 'ditolak' WHERE id_booking = @id_booking;
        
        -- Kembalikan status jadwal menjadi 'tersedia'
        UPDATE tbl_jadwal SET status = 'tersedia' WHERE id_jadwal = @id_jadwal;
        
        COMMIT TRANSACTION;
        SET @pesan = 'SUKSES: Booking berhasil dibatalkan!';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @pesan = 'GAGAL: ' + ERROR_MESSAGE();  -- ✅ Perbaiki typo: ERROR_NESSAGE → ERROR_MESSAGE
    END CATCH
END;
GO


CREATE TRIGGER trg_CekJadwalBentrok
ON tbl_booking
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Jika ada jadwal yang sama, di studio yang sama, pada tanggal yang sama dimasukkan lagi
    IF EXISTS (
        SELECT 1 
        FROM tbl_booking b
        JOIN inserted i ON b.id_jadwal = i.id_jadwal 
        WHERE b.id_booking <> i.id_booking 
          AND b.tanggal_booking = i.tanggal_booking
          AND b.status IN ('disetujui', 'selesai')
    )
    BEGIN
        RAISERROR ('Maaf, jadwal studio pada tanggal tersebut sudah dibooking orang lain!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


CREATE PROCEDURE sp_InsertBooking
    @id_pelanggan INT,
    @id_jadwal INT,
    @tanggal_booking DATE,
    @durasi_jam INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @harga_per_jam DECIMAL(18,2);
    DECLARE @total_harga DECIMAL(18,2);

    -- 1. Ambil harga studio berdasarkan jadwal yang dipilih
    SELECT @harga_per_jam = s.harga_per_jam 
    FROM tbl_jadwal j
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE j.id_jadwal = @id_jadwal;

    -- 2. Hitung total harga otomatis
    SET @total_harga = @harga_per_jam * @durasi_jam;

    -- 3. Insert ke tbl_booking
    INSERT INTO tbl_booking (id_pelanggan, id_jadwal, tanggal_booking, total_harga, status)
    VALUES (@id_pelanggan, @id_jadwal, @tanggal_booking, @total_harga, 'disetujui');
    
    -- Mengembalikan nilai untuk konfirmasi di backend C#
    SELECT SCOPE_IDENTITY() AS NewBookingID, @total_harga AS TotalHarga;
END;


CREATE TRIGGER trg_CekJadwalBentrok
ON tbl_booking
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1 
        FROM tbl_booking b
        JOIN inserted i ON b.id_jadwal = i.id_jadwal 
        WHERE b.id_booking <> i.id_booking 
          AND b.tanggal_booking = i.tanggal_booking
          AND b.status IN ('disetujui', 'selesai')
    )
    BEGIN
        RAISERROR ('Maaf, jadwal studio pada tanggal tersebut sudah dibooking orang lain!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

CREATE PROCEDURE sp_InsertBooking
    @id_pelanggan INT,
    @id_jadwal INT,
    @tanggal_booking DATE,
    @durasi_jam INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @harga_per_jam DECIMAL(18,2);
    DECLARE @total_harga DECIMAL(18,2);

    -- Ambil harga studio berdasarkan jadwal yang dipilih
    SELECT @harga_per_jam = s.harga_per_jam 
    FROM tbl_jadwal j
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE j.id_jadwal = @id_jadwal;

    -- Hitung total harga otomatis
    SET @total_harga = @harga_per_jam * @durasi_jam;

    -- Simpan data booking
    INSERT INTO tbl_booking (id_pelanggan, id_jadwal, tanggal_booking, total_harga, status)
    VALUES (@id_pelanggan, @id_jadwal, @tanggal_booking, @total_harga, 'disetujui');
    
    -- Kembalikan nilai total harga untuk ditangkap di VS C#
    SELECT SCOPE_IDENTITY() AS NewBookingID, @total_harga AS TotalHarga;
END;




CREATE TRIGGER trg_OtomatisUpdateStatusJadwal
ON tbl_booking
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cek jika status diubah dari yang lain menjadi 'disetujui'
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN deleted d ON i.id_booking = d.id_booking
        WHERE i.status = 'disetujui' AND d.status <> 'disetujui'
    )
    BEGIN
        -- Otomatis ubah status di tbl_jadwal menjadi 'dipesan'
        UPDATE j
        SET j.status = 'dipesan'
        FROM tbl_jadwal j
        JOIN inserted i ON j.id_jadwal = i.id_jadwal
        WHERE i.status = 'disetujui';
    END
END;


CREATE PROCEDURE sp_InsertBookingUser
    @id_pelanggan INT,
    @id_jadwal INT,
    @tanggal_booking DATE,
    @durasi_jam INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @harga_per_jam DECIMAL(18,2);
    DECLARE @total_harga DECIMAL(18,2);

    -- Ambil harga studio secara internal di database
    SELECT @harga_per_jam = s.harga_per_jam 
    FROM tbl_jadwal j
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE j.id_jadwal = @id_jadwal;

    -- Hitung total harga otomatis
    SET @total_harga = @harga_per_jam * @durasi_jam;

    -- Simpan dengan status awal 'menunggu' (karena butuh approval admin di riwayat)
    INSERT INTO tbl_booking (id_pelanggan, id_jadwal, tanggal_booking, total_harga, status)
    VALUES (@id_pelanggan, @id_jadwal, @tanggal_booking, @total_harga, 'menunggu');

    SELECT SCOPE_IDENTITY() AS NewBookingID, @total_harga AS TotalHarga;
END;


CREATE VIEW vw_JadwalTersedia AS
SELECT 
    j.id_jadwal, 
    s.nama_studio, 
    j.tanggal, 
    j.jam_mulai, 
    j.jam_selesai, 
    s.harga_per_jam,
    CAST(DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60.0 AS DECIMAL(5,1)) AS durasi_jam
FROM tbl_jadwal j
JOIN tbl_studio s ON j.id_studio = s.id_studio
WHERE s.status = 'aktif' AND j.tanggal >= CAST(GETDATE() AS DATE);


CREATE PROCEDURE sp_InsertBooking
    @id_pelanggan INT,
    @id_jadwal INT,
    @catatan VARCHAR(255),
    @new_id INT OUTPUT,
    @pesan VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Validasi apakah jadwal sudah dibooking orang lain yang statusnya sukses/pending
    IF EXISTS (SELECT 1 FROM tbl_booking WHERE id_jadwal = @id_jadwal AND status != 'batal')
    BEGIN
        SET @new_id = 0;
        SET @pesan = 'GAGAL: Jadwal ini sudah dibooking oleh pelanggan lain!';
        RETURN;
    END

    -- Jika aman, lakukan insert
    INSERT INTO tbl_booking (id_pelanggan, id_jadwal, tanggal_booking, catatan, status)
    VALUES (@id_pelanggan, @id_jadwal, GETDATE(), @catatan, 'Sukses');

    SET @new_id = SCOPE_IDENTITY();
    SET @pesan = 'SUKSES: Booking studio berhasil dibuat!';
END;





CREATE PROCEDURE sp_CancelBooking
    @id_booking INT,
    @id_pelanggan INT,
    @pesan VARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cek apakah booking emang punya pelanggan tersebut dan belum batal
    IF EXISTS (SELECT 1 FROM tbl_booking WHERE id_booking = @id_booking AND id_pelanggan = @id_pelanggan AND status = 'Sukses')
    BEGIN
        UPDATE tbl_booking
        SET status = 'Batal'
        WHERE id_booking = @id_booking;

        SET @pesan = 'SUKSES: Booking berhasil dibatalkan!';
    END
    ELSE
    BEGIN
        SET @pesan = 'GAGAL: Data tidak ditemukan atau sudah dibatalkan sebelumnya.';
    END
END;




CREATE PROCEDURE sp_SearchRiwayatBooking
    @id_pelanggan INT,
    @status VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.id_booking,
        b.tanggal_booking,
        s.nama_studio,
        DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60 AS durasi_jam,
        (DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60) * s.harga_per_jam AS total_harga,
        b.status
    FROM tbl_booking b
    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
    JOIN tbl_studio s ON j.id_studio = s.id_studio
    WHERE b.id_pelanggan = @id_pelanggan
      AND (@status = 'semua' OR b.status = @status)
    ORDER BY b.tanggal_booking DESC;
END;